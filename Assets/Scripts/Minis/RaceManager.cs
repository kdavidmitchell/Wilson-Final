/*RaceManager.cs

This script determines the behavior of the campaign race in the minigame.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{

    //get references to all the candidates
    public GameObject wilson;
    public GameObject taft;
    public GameObject teddy;
    public GameObject debs;

    //reference to the character select menu
    public GameObject characterSelect;

    void Awake()
    {
        //set everything to inactive initially
        wilson.SetActive(false);
        taft.SetActive(false);
        teddy.SetActive(false);
        debs.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    //A function that enables the racers.
    public void EnableRacers()
    {
        wilson.SetActive(true);
        taft.SetActive(true);
        teddy.SetActive(true);
        debs.SetActive(true);
    }

    //A function that disables the character select menu.
    public void DisableCharacterSelect()
    {
        characterSelect.SetActive(false);
    }
}
