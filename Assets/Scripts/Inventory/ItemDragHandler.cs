using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler 
{
    //**NOTE** An item must have an image component in order to function.
    //allows the item to be dragged with the pointer.

    public RectTransform canvasRectTransform;
    private Vector2 dragOffset;

    public static GameObject itemBeingDragged;
    public static Item actualItem;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position, Camera.main, out pos))
        {
            dragOffset = (Vector2)transform.position - (Vector2)canvasRectTransform.TransformPoint(pos);
            transform.SetParent(canvasRectTransform, true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        actualItem = new Item();

        Debug.Log(itemBeingDragged.GetComponent<Image>().sprite.name);
        actualItem = GameManager.inventory[GameManager.ParseClick(itemBeingDragged.GetComponent<Image>().sprite.name)];

        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position, Camera.main, out pos);
     
        transform.position = canvasRectTransform.TransformPoint(pos) + (Vector3)dragOffset;
    }

    //item will snap back to it's original position if not being dragged or being given to Wilson
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }
}
