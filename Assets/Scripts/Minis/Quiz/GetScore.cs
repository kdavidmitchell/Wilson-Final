using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {

    public Text playerScore;
    public int score;
    public int itemScore;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt("Score Display");
        playerScore = FindObjectOfType<Text>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
