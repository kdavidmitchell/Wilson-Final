using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWIManager : MonoBehaviour 
{
	public static float spawnTimer = 2f;
	public static bool canSpawn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnTimer -= Time.deltaTime;

		if (spawnTimer <= 0)
		{
			canSpawn = true;
		}
	}
}
