/*Racer.cs

A script attached to a gameobject meant to represent one of the candidates in the campaign race minigame.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Racer : MonoBehaviour
{
    //is this racer the player?
    public bool player = false;

    //modifier to speed
    public float force;

    //position and length (in time, s) of race
    private Vector3 pos;
    private float timer = 7f;

	// Use this for initialization
	void Start ()
    {
        //get start position of each racer
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //decrement timer
    	timer -= Time.deltaTime;

        //if a racer is not the player and timer is greater than 0
        if (!player && timer > 0)
        {
            //move the racer along a straight line
            pos.x += 0.1f * force * Time.deltaTime;
            transform.position = pos;
        //or if the racer is the player 
        } else if (timer >= 0)
        {
            //when the player clicks the mouse
        	if (Input.GetKeyDown(KeyCode.Mouse0))
        	{
                //move the racer along a straight line
            	pos.x += 0.01f * 15f;
            	transform.position = pos;
        	}
        //if the timer is up
        } else
        {
            //stop everything
        	return;
        }
    }

    //A function that just determines if the racer is the player.
    public void SetPlayer()
    {
        player = true;
    }

}
