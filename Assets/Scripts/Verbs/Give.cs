using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Verbs/Give")]
public class Give : InputVerb
{

    public Button itemButton;

    private GameObject itemButtonHolder;
    private GameObject[] itemsForDestruction;

    public override void RespondToChoice()
    {
        itemButtonHolder = GameObject.Find("Item_Button_Holder");

        //change current action
        GameManager.ChangeCurrentAction(0);

        //update action text
        GameManager.UpdateActionText(GameManager.verbs[0].actionText);
        //update dialogue text
        GameManager.UpdateDialogueText("Give which item?");

        //change status of itemclickhandler isGiving to true
        ItemClickHandler.isGiving = true;

        itemsForDestruction = GameObject.FindGameObjectsWithTag("Destroy");
        DestroyButtons();

        foreach (Item item in GameManager.inventory)
        {
            Button objectToBeInstantiated;
            Text buttonText;

            objectToBeInstantiated = Instantiate(itemButton, itemButtonHolder.transform.position, Quaternion.identity);
            objectToBeInstantiated.transform.parent = itemButtonHolder.transform;
            objectToBeInstantiated.transform.localScale = Vector3.one;

            Color c;
            c = objectToBeInstantiated.GetComponent<Image>().color;
            c.a = 0;
            objectToBeInstantiated.GetComponent<Image>().color = c;

            buttonText = objectToBeInstantiated.GetComponentInChildren<Text>();
            buttonText.text = item.ItemName;

            AnimatorManager am = GameObject.FindGameObjectWithTag("Wilson").GetComponent<AnimatorManager>();
            objectToBeInstantiated.onClick.AddListener(() => am.Talk());
            objectToBeInstantiated.onClick.AddListener(() => GameManager.inventory.Remove(item));
            objectToBeInstantiated.onClick.AddListener(() => Debug.Log(GameManager.inventory.Count));
            objectToBeInstantiated.onClick.AddListener(() => GameManager.UpdateDialogueText(item.ValidGive));
            objectToBeInstantiated.onClick.AddListener(() => itemsForDestruction = GameObject.FindGameObjectsWithTag("Destroy"));
            objectToBeInstantiated.onClick.AddListener(() => DestroyButtons());
        }

        //give item from inventory to person
        //1. get what item is selected
        //2. remove it from inventory
        //3. if target is not wilson -- return
    }

    private void DestroyButtons()
    {
        if (itemsForDestruction != null)
        {
            for (int i = 0; i < itemsForDestruction.Length; i++)
            {
                Destroy(itemsForDestruction[i]);
            }
        }
    }
}
