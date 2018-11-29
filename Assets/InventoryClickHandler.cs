using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryClickHandler : MonoBehaviour, IPointerClickHandler 
{

	public void OnPointerClick(PointerEventData eventData)
    {
        Item itemClicked = new Item();
        Debug.Log(gameObject.GetComponent<Image>().sprite.name);
        itemClicked = GameManager.inventory[GameManager.ParseClick(gameObject.GetComponent<Image>().sprite.name)];
        GameManager.ShowItemDescription(itemClicked);
    }
}
