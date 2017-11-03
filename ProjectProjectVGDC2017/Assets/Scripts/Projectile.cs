﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public GameObject shot;
    private Vector2 position;
    private float speed, direction, xAwayFromTarget, yAwayFromTarget;
    private bool aimed;
    //xAway and yAway for shots aimed at a position, direction for shots fired at a specific angle (360 degrees)
	// Use this for initialization
	void Start () {
        position = shot.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (aimed)
        {
            direction = (Mathf.Rad2Deg * (Mathf.Atan2(xAwayFromTarget, yAwayFromTarget)) - 90);
            shot.transform.position = new Vector2(shot.transform.position.x + (speed * Mathf.Cos(Mathf.Deg2Rad * (Mathf.Rad2Deg * (Mathf.Atan2(xAwayFromTarget, yAwayFromTarget)) - 90))), shot.transform.position.y - (speed * Mathf.Sin(Mathf.Deg2Rad * (Mathf.Rad2Deg * (Mathf.Atan2(xAwayFromTarget, yAwayFromTarget)) - 90))));
        }
        else
        {
            position = new Vector2(position.x + (speed * Mathf.Cos(Mathf.Deg2Rad * direction)), position.y - (speed * Mathf.Sin(Mathf.Deg2Rad * direction)));
            shot.transform.position = position;
        }
    }
    public void spawnAimed(Vector2 p,float s, float xAway,float yAway)
    {
        shot.transform.position = p;
        speed = s;
        xAwayFromTarget = xAway;
        yAwayFromTarget = yAway;
        aimed = true;
    }
    public void spawnDirectional(Vector2 p, float s, float dir)
    {
        shot.transform.position = p;
        speed = s;
        direction = dir;
        aimed = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Stuff happens when hitting player
        }
    }
}