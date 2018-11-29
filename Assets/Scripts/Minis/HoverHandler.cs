/*HoverHandler.cs

This script is an interface meant to handle the hover menus that appear during the WWI minigame.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //what should it actually read
    public string message;
    //get reference to the Text component
    private Text hoverText;
    //get reference to the Boat component
    private Boat boat;

	// Use this for initialization
	void Awake()
    {
        //references
        boat = GameObject.Find("Boat").GetComponent<Boat>();
        hoverText = GameObject.Find("Hover_Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*This function determines what happens when a particular option is hovered over.*/
    public void OnPointerEnter(PointerEventData eventData)
    {
        //set the hover menu to active
        boat.hover.SetActive(true);
        //change the text of the object to read the message
        hoverText.text = message;
    }

    /*This function determines what happens when a particular option is no longer hovered over.*/
    public void OnPointerExit(PointerEventData eventData)
    {
        //set the hover menu to inactive
        boat.hover.SetActive(false);
    }
}
