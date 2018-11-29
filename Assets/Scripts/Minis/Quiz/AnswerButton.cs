using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnswerButton : MonoBehaviour {

    public Text answerText;
    private AnswerData answerData;
    private GameController gameController;

    public AudioSource incorrectSource;
    //public AudioSource correctSource;
    public AudioClip correct;
    public AudioClip incorrect;

	// Use this for initialization
	void Start ()
    {
        gameController = FindObjectOfType<GameController>();
        incorrectSource = GetComponent<AudioSource>();
        //correctSource = GetComponent<AudioSource>();
    }
	
    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }

    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);

        /*if (answerData.isCorrect == true)
        {
            incorrectSource.PlayOneShot(correct, 1f);
            Debug.Log("Correct!");
        }
        else
        {
            incorrectSource.PlayOneShot(incorrect, 1f);
            Debug.Log("Wrong!");
        }*/
    }

 
}
