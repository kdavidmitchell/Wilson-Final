/*Boat.cs

This script determines the behavior of the boat found in the WWI minigame.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boat : MonoBehaviour
{
    //load in a gameobject that will be used as a projectile
    public GameObject missile;
    public int health = 100;
    //asign a gameobject that will be used to provide information in a hover panel
    public GameObject hover;
    //assign the tower that will be destroyed
    public GameObject Tower;
    Animator anim;

    public static int currentIndex;

	// Use this for initialization
	void Start ()
    {
        //get the hover panel, set it to false, and then get the animator component of the tower
        hover = GameObject.Find("Hover_Panel");
        hover.SetActive(false);
        anim = Tower.GetComponent<Animator>();
        //???
        anim.GetBool("done");
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        //on update check if health is at or below zero
	    if (health <= 0)
        {
            //if it is
            anim.SetBool("done", true);
            //make the tower fall and load the next scene
            StartCoroutine(LoadScene());
        }
	}

    /*A function that takes an int index and fires a projectile from the boat, damaging the tower in the minigame.
    Index will determine the amount of damage done to the tower.*/
    public void FireMissile(int index)
    {
        GameObject objectToBeInstantiated = Instantiate(missile, transform.position, Quaternion.identity);
        //health -= index;
        currentIndex = index;
    }

    
    /*A simple coroutine designed to allow a delay before loading the next scene.*/
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(6);
        print(Time.time);
        AudioManager am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        am.DestroyAudioSource();
        am.LoadNextLevel("Big4");
    }
}
