/*HoverHandlerCampaign.cs

This script is an interface meant to handle the hover menus that appear during the campaign minigame.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverHandlerCampaign : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //what should the hover message be
    public string message;

    private Text hoverText;
    private GameObject explainer;

    // Use this for initialization
    void Awake()
    {
        //get references to both the container for the message and the text component itself
        explainer = GameObject.Find("Explainer");
        hoverText = GameObject.Find("Hover_Text").GetComponent<Text>();
    }

    void Start()
    {
        //set the container to inactive
        explainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*This function determines what happens when a particular option is hovered over.*/
    public void OnPointerEnter(PointerEventData eventData)
    {
        //set the container to active
        explainer.SetActive(true);
        //change the actual text of the object
        hoverText.text = message;
    }

    /*This function determines what happens when a particular option is no longer hovered over.*/
    public void OnPointerExit(PointerEventData eventData)
    {
        //set the container to inactive
        explainer.SetActive(false);
    }
}
