﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DataController : MonoBehaviour {

    public RoundData[] allRoundData;
	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
       // SceneManager.LoadScene("Quiz Final");

    }
    public RoundData getCurrentRoundData()
    {
        return allRoundData[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
