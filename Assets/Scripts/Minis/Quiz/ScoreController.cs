using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ScoreController : MonoBehaviour {

    public int finalScore;

   
    public Text scoreText;
    public int score;

	// Use this for initialization
	void Start () {

       
	}
	
	public void PlayCutscene()
    {
        if (score <= 29)
        {
            SceneManager.LoadScene("Bad End");
        }

        else if (score >= 30 && score <= 50)

        {
            SceneManager.LoadScene("Good End");
        }

        else if (score <= 80 && score >= 60)
        {
            SceneManager.LoadScene("True End");
        }
    }
}
