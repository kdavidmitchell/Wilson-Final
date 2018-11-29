using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiveManager : MonoBehaviour 
{

	private int maxItems;
	public ItemDropHandler handler;

	// Use this for initialization
	void Start () 
	{
		maxItems = GameManager.inventory.Count;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameManager.itemsGiven == maxItems)
		{
			handler.PlayCutscene();
		}	
	}
}
