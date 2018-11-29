/*ItemClickHandler.cs

This script handles the parsing of clicks on any object in the game--be it a person or an item.
It first determines what exactly the object clicked on is, and then decides the context of the click
based on what state the game is currently in, determined by GameManager.cs.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemClickHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //string containing the previous action text
    private string previous;
    //an array of gameobjects that can be destroyed
    private GameObject[] itemsForDestruction;
    //a place for buttons to spawn pertaining to the various items the player acquires throughout the game
    public GameObject itemButtonHolder;
    public Button buttonPrefab;
    //bool that determines if the player is currently giving an item to Wilson
    public static bool isGiving = false;

    /*A function that determines what happens when an object in the game is clicked. This determines what
    exactly was clicked and then parses it based on that information. */
	public void OnPointerClick(PointerEventData eventData)
    {
        //destroy unnecessary buttons after player clicks on something
        itemsForDestruction = GameObject.FindGameObjectsWithTag("Destroy");
        DestroyButtons();

        //check if the object is of type Item using its name
        if (CheckIfClickIsItem(name))
        {
            //parse the click -- determine what the player is trying to do with the item
            ParseItemClicks(name);
        }
        //else if (CheckIfClickIsInventory(name))
        //{
        //    ParseInventoryClicks(name);
        //}
        //check if the object is of type Person using its name
        else if (CheckIfClickIsPerson(name))
        {
            //parse the click -- determine what the player is trying to do with the person
            ParsePersonClicks(name);
        }
    }

    /*A function that determines what happens when an object in the game is hovered over.*/
    public void OnPointerEnter(PointerEventData eventData)
    {
        //if the player isn't trying to give an item to Wilson
        if (!isGiving)
        {
            //if the object is Wilson
            if (name.Contains("Wilson"))
            {
                //make the action text window say Wilson
                Debug.Log("Hovering over wilson");
                previous = GameManager.actionText.text;
                GameManager.actionText.text += " Wilson";
            //if the object is part of the UI
            } else if (name.Contains("Icon"))
            {
                //just cancel the function
                return;
            //if the object is none of those
            } else 
            {
                //set previous to the current text of the action text window and then update it
                //with the object's name
                previous = GameManager.actionText.text;
                GameManager.actionText.text += " " + name;    
            }
        }
        //if the player is giving an item, don't do anything on hovering over an object
        else
        {
            return;
        }
    }

    /*A function that determines what happens when an object in the game no longer has a cursor hovering on it.*/
    public void OnPointerExit(PointerEventData eventData)
    {
        //if the player is not giving an item to wilson
        if (!isGiving)
        {
            //return the action text window to what it said previously
            GameManager.UpdateActionText(previous);
        }
        //if the player is giving something
        else
        {
            //just quit the function
            return;
        }
    }

    /*A function that returns type Item via the string name. Useful for wanting to get the class type of
    an item with only its name.*/
    private Item FindItemByName(string name)
    {
        foreach (Item item in ItemDB.items)
        {
            if (item.ItemName == name)
            {
                return item;
            }
        }
        return null;
    }

    /*A function that returns true if the given string name is the name of an Item.*/
    private bool CheckIfClickIsItem(string name)
    {
        foreach (Item item in ItemDB.items)
        {
            if (item.ItemName == name)
            {
                return true;
            }
        }
        return false;
    }

    //private bool CheckIfClickIsInventory(string name)
    //{
    //    foreach (GameObject slot in GameManager.inventorySlots)
    //    {
    //        if (slot.name == name)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    /*A function that returns true if the given string name is the name of a Person.*/
    private bool CheckIfClickIsPerson(string name)
    {
        foreach (Person person in PeopleDB.people)
        {
            if (person.PersonName == name)
            {
                return true;
            }
        }
        return false;
    }

    /*A function that returns type Person via the string name. Useful for wanting to get the class type of
    a person with only its name.*/
    private Person FindPersonByName(string name)
    {
        foreach (Person person in PeopleDB.people)
        {
            if (person.PersonName == name)
            {
                return person;
            }
        }
        return null;
    }

    /*A function that determines the context of a click given the name of the item clicked on.*/
    private void ParseItemClicks(string name)
    {
        //first, get the Item
        Item itemClicked = new Item();
        itemClicked = FindItemByName(name);

        //find all game objects of type Person in the scene and set their animations to idle
        GameObject[] people = GameObject.FindGameObjectsWithTag("Person");
        for (int i = 0; i < people.Length; i++)
        {
            AnimatorManager am = people[i].GetComponent<AnimatorManager>();
            am.ResetToIdle();
        }

        //if the player is attempting to look at an item
        if (GameManager.currentAction == 2)
        {
            //update the dialogue box with the item's description
            GameManager.UpdateDialogueText(itemClicked.ItemDescription);
        }
        //if the player is attempting to talk to an item
        else if (GameManager.currentAction == 3)
        {
            if (GameManager.levelIndex == 0)
            {
                //dont let them
                GameManager.UpdateDialogueText("You can't talk to this.");
            }
        }
        //if the player is attempting to pick up an item
        else if (GameManager.currentAction == 4)
        {
            //find the gameobject to be removed from the scene
            GameObject objectToBeDestroyed = GameObject.Find(name);

            //reflect that they picked the item up in the dialogue box
            GameManager.UpdateDialogueText("You picked up: " + name);
            //add the item to the player's inventory
            GameManager.inventory.Add(itemClicked);
            Debug.Log("Added " + itemClicked.ItemName + " to inventory");
            GameManager.UpdateInventory(objectToBeDestroyed.GetComponent<Image>().sprite);
            //destroy the gameobject pertaining to the Item
            Destroy(GameObject.Find(name));
            //reset the action text window
            GameManager.UpdateActionText(" ");

            GameManager.ChangeCurrentAction(2);
        }

        //if the player isnt trying to pick up an item, they're probably trying to look at it
        if (GameManager.currentAction != 4)
        {
            //so give the description
            GameManager.UpdateDialogueText(itemClicked.ItemDescription);
        }
    }

    //private void ParseInventoryClicks(string name)
    //{
    //    Item itemClicked = new Item();

    //    if (GameManager.currentAction == 0)
    //    {
    //        itemClicked = GameManager.inventory[GameManager.ParseClick(name)];
    //        ItemClickHandler.hasSelectedItem = true;
    //        GameManager.UpdateActionText("Give " + itemClicked.ItemName + " to whom?");
    //        lastItem = itemClicked;
    //    }
    //}

    /*A function that determines the context of a click given the name of the person clicked on.*/
    private void ParsePersonClicks(string name)
    {
        //first, get the Person
        Person personClicked = new Person();
        personClicked = FindPersonByName(name);

        //if (GameManager.currentAction == 0)
        //{
        //    if (!ItemClickHandler.hasSelectedItem)
        //    {
        //        GameManager.UpdateDialogueText("I wouldn't, if I were you.");
        //    }
        //    else if (ItemClickHandler.hasSelectedItem)
        //    {
        //        GameManager.UpdateDialogueText(lastItem.ValidGive);
        //    }
        //    ItemClickHandler.isGiving = false;
        //}
        //else if (GameManager.currentAction == 2)
        //{
        //    GameManager.UpdateDialogueText(personClicked.PersonLook);
        //}
        //else if (GameManager.currentAction == 3)
        //{
        //    int determinant;
        //    determinant = (GameManager.levelIndex % 2);

        //    if (determinant >= 0)
        //    {
        //        GameManager.UpdateDialogueText(personClicked.PersonTalk0);
        //    }
        //    else
        //    {
        //        GameManager.UpdateDialogueText(personClicked.PersonTalk1);
        //    }

        //if the player is trying to look at the person
        if (GameManager.currentAction == 2)
        {
            //update the dialogue box with their description
            GameManager.UpdateDialogueText(personClicked.PersonLook);
            //reset default action to talk
            GameManager.currentAction = 3;
            //wipe the action text window
            previous = "";
            GameManager.UpdateActionText("");

            //reset the person's animation to idle, because the player isn't talking to them
            AnimatorManager am = gameObject.GetComponent<AnimatorManager>();
            am.ResetToIdle();
        }
        //if the player is attempting to pick the person up
        else if (GameManager.currentAction == 4)
        {
            //dont let them
            GameManager.UpdateDialogueText("\"Um. Please put me down.\"");
            AnimatorManager am = gameObject.GetComponent<AnimatorManager>();
            am.Talk();
            GameManager.currentAction = 3;
            previous = "";
            GameManager.UpdateActionText("");
        }
        else
        {
            //the default case -- talk to the person
            //find the animator manager of the person clicked on, then find all the animator managers
            //attached to other people in the scene. if there is no match, set that animator to idle
            //and set the one just clicked on to talk.
            AnimatorManager am = gameObject.GetComponent<AnimatorManager>();
            GameObject[] people = GameObject.FindGameObjectsWithTag("Person");
            for (int i = 0; i < people.Length; i++)
            {
                AnimatorManager otherAM = people[i].GetComponent<AnimatorManager>();
                if (otherAM != am)
                {
                    otherAM.ResetToIdle();
                }
            }
            am.Talk();

            //simple math to determine whether or not the scene index is odd or even
            int determinant;
            determinant = (GameManager.levelIndex % 2);

            //if the scene index is even
            if (determinant >= 0)
            {
                //make the person say their first talk option
                GameManager.dialogueText.text = personClicked.PersonTalk0;
                //add all questions and answers for the person to lists
                List<string> questions = new List<string>();
                List<string> answers = new List<string>();
                questions.Add(personClicked.PersonQuestion0);
                questions.Add(personClicked.PersonQuestion1);
                answers.Add(personClicked.PersonAnswer0);
                answers.Add(personClicked.PersonAnswer1);
                Debug.Log(questions[0]);
                Debug.Log(questions[1]);
                Debug.Log(answers[0]);
                Debug.Log(answers[1]);

                //make buttons for each question
                foreach (string question in questions)
                {
                    Button objectToBeInstantiated;
                    Text buttonText;

                    objectToBeInstantiated = Instantiate(buttonPrefab, itemButtonHolder.transform.position, Quaternion.identity);
                    objectToBeInstantiated.transform.parent = itemButtonHolder.transform;
                    objectToBeInstantiated.transform.localScale = Vector3.one;

                    Color c;
                    c = objectToBeInstantiated.GetComponent<Image>().color;
                    c.a = 0;
                    objectToBeInstantiated.GetComponent<Image>().color = c;

                    buttonText = objectToBeInstantiated.GetComponentInChildren<Text>();
                    buttonText.text = question;
                    buttonText.fontSize = 20;
                    buttonText.fontStyle = FontStyle.Italic;

                    objectToBeInstantiated.onClick.AddListener(() => GameManager.UpdateDialogueText(answers[questions.IndexOf(question)]));
                    objectToBeInstantiated.onClick.AddListener(() => itemsForDestruction = GameObject.FindGameObjectsWithTag("Destroy"));
                    objectToBeInstantiated.onClick.AddListener(() => DestroyButtons());
                }
            }
            //if the scene index is odd, make the person say their second talk option
            else
            {
                GameManager.dialogueText.text = personClicked.PersonTalk1;
            }
        }
    }

    /*A function that allows the destruction of buttons that aren't used.*/
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
