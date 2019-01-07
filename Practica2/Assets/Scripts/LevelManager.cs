﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum LevelState { PLAY, PAUSE, DANGER, DEAD};
public class LevelManager : MonoBehaviour {
    private BallSpawner bSpawn;
    public BallSink bSink;
    public DeathZone dZone;
    public Advertising adv;
    public TouchDetect tDetect;

    public RectTransform CanvasJuego;

    [Range(1,312)]
    public int Level = 1;

    private uint _numBalls;

    // Use this for initialization
    void Start () {
        bSpawn = this.gameObject.GetComponent<BallSpawner>();
        //Carga el txt del nivel seleccionado
        GetComponent<BoardManager>().SetLevel(Level);

        // 1.Empieza el nivel y coloca el bSink y el bSpawn, se añade una estrella al score
        bSink.hide();
        dZone.init(this,bSink);
        _numBalls = 50;

        Vector3 tam = GetComponent<BoardManager>().GetTam();

        bSpawn.setScale(tam);
        bSpawn.setLaunchPos(0, dZone.gameObject.transform.position.y);
        bSink.setPos(0, dZone.gameObject.transform.position.y);
        bSink.setNumBalls(_numBalls);
        bSink.show();
        bSink.init(tam);
        ///Hay que añadir una estrella a la puntuación 

        // 2.Se activa el detector de pulsación
        tDetect.init(this,bSpawn);
	}
	
    void activateTouch() {
        tDetect.enabled = true;
    }

    void deactivateTouch() {
        tDetect.enabled = false;
    }

    public void onLastBallArrived() {
        Vector2 pos = bSink.getPos();
        bSpawn.setLaunchPos(pos.x, pos.y);
        bSpawn.gameObject.SetActive(true);
        tDetect.gameObject.SetActive(true);
        GetComponent<BoardManager>().StepForwardBlocks();
    }

    public uint GetNumBalls() { return _numBalls; }

    public void hideBallSink() { bSink.hide(); }
}
