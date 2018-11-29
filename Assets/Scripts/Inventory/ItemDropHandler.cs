using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ItemDropHandler : MonoBehaviour, IDropHandler 
{

	public RectTransform wilson;
	public int score;

	public void OnDrop(PointerEventData eventData)
    {
    	Vector2 pos;
    	if (RectTransformUtility.ScreenPointToLocalPointInRectangle(wilson, eventData.position, Camera.main, out pos))
        {
            if (GameManager.itemsGiven < 3)
            {
                Debug.Log("Item accepted");
                Destroy(ItemDragHandler.itemBeingDragged);

                GameManager.UpdateScore(ItemDragHandler.actualItem);
                GameManager.UpdateWilsonGiveText(ItemDragHandler.actualItem);
                GameManager.itemsGiven++; 
            } else if (GameManager.itemsGiven == 2) 
            {
                Destroy(ItemDragHandler.itemBeingDragged);
                GameManager.UpdateScore(ItemDragHandler.actualItem);
                GameManager.UpdateWilsonGiveText(ItemDragHandler.actualItem);
                GameManager.itemsGiven++;

                //This is where you can write the scene transition code using GameManager.quizScore and whatever score brackets you are using to determine the final cutscene

                score = GameManager.quizScore;
                PlayCutscene();
            }
        }
    }

    public void PlayCutscene()
    {
    	if (score >= 0 && score <= 65)
    	{
    		SceneManager.LoadScene("Bad End");
    	} else if (score >= 66 && score <= 84) 
    	{
    		SceneManager.LoadScene("Good End");
    	} else if (score >= 85)
    	{
    		SceneManager.LoadScene("True End");
    	}
    }
}
