﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    public Ball ball;
    //public int numBalls;
    // Use this for initialization
    void Start () {
        //numBalls = 10;
        //spawnBalls();
    }

    // Update is called once per frame
    /*void Update () {


        //Intento chusco
        if (Input.GetKeyUp(KeyCode.C))
        {
            //ball1.GetComponent<Ball>().startMove();
        }
        else if (Input.GetKeyUp(KeyCode.V))
        {
            //ball2.GetComponent<Ball>().startMove();
        }
    }*/

    //Falta la dirección que van a tomar las bolas
    public void spawnBalls(uint numBalls) {
        StartCoroutine(spawnBallsCoroutine(numBalls));
    }

    public void setLaunchPos(float x, float y) {
        posX = x; posY = y;
    }


    IEnumerator spawnBallsCoroutine(uint numBalls)
    {
        for (int i = 0; i < numBalls; i++)
        {
            Ball actB = Instantiate(ball);
            actB.init();
            actB.startMove(new Vector2(posX,posY),speed);
            yield return new WaitForFixedUpdate();
        }
        gameObject.SetActive(false);
    }

    private float posX, posY;
    private Vector2 speed = new Vector2(5, 50);
}
