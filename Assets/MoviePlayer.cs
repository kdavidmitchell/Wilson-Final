using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MoviePlayer : MonoBehaviour 
{

	public VideoPlayer player;
	public string videoName;
	public int followSceneIndex;

	// Use this for initialization
	void Start () 
	{
		PlayMovie();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayMovie()
	{
		player.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
		player.loopPointReached += EndReached;
		player.Prepare();
		player.Play();
	}

	void EndReached(VideoPlayer player)
	{
		SceneManager.LoadScene(followSceneIndex);
	}
}
