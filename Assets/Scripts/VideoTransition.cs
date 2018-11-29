using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoTransition : MonoBehaviour {
    public VideoPlayer opener;

	// Use this for initialization
	void Start ()
    {
        opener.loopPointReached += SwitchScene;
	}

    

    // Update is called once per frame
    void Update () {
		
	}

    public void SwitchScene(VideoPlayer vp)
    {
        SceneManager.LoadScene("BrynMawr_1");
    }
}
