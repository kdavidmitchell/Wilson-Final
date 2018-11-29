using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<GameObject> tutorialMessages = new List<GameObject>();
    private GameObject tutorialMessage;

    public InputVerb[] verbArray = new InputVerb[5];
    private GameObject tutorialOverlay;

    private static Text finalScore;
    private static GameObject giveText;
    private static GameObject clickText;

    public static Text actionText;
    public static Text dialogueText;

    public static GameManager instance = null;
    public static InputVerb[] verbs = new InputVerb[5];
    public static int currentAction = 0;
    public static int levelIndex = 0;
    public static List<Item> inventory = new List<Item>();
    public static List<Sprite> inventorySlots = new List<Sprite>();
    public static int quizScore = 0;
    public static int itemsGiven = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != null)
        {
            Destroy(gameObject);
        }

        actionText = GameObject.Find("Speech_Text").GetComponent<Text>();
        dialogueText = GameObject.Find("Dialogue_Text").GetComponent<Text>();
        tutorialOverlay = GameObject.Find("Tutorial_Overlay");

        for (int i = 0; i < verbArray.Length; i++)
        {
            verbs[i] = verbArray[i];
        }

        //for (int i = 0; i < 7; i++)
        //{
        //    inventorySlots.Add(GameObject.Find("Slot_" + i + "_Icon"));
        //}

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Tutorial").Length; i++)
        {
            tutorialMessages.Add(GameObject.Find("Overlay_" + i));
        }

        if (tutorialMessages.Count != 0)
        {
            Debug.Log(tutorialMessages.Count);
            foreach (GameObject tut in tutorialMessages)
            {
                tut.SetActive(false);
            }

            tutorialMessage = tutorialMessages[0];
            tutorialMessage.SetActive(true);
        }

        DontDestroyOnLoad(gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 4 || level == 7)
        {
            tutorialOverlay = GameObject.Find("Tutorial_Overlay");
            tutorialMessages.Clear();

            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Tutorial").Length; i++)
            {
                tutorialMessages.Add(GameObject.Find("Overlay_" + i));
            }

            if (tutorialMessages.Count != 0)
            {
                foreach (GameObject toot in tutorialMessages)
                {
                    toot.SetActive(false);
                }

                tutorialMessage = tutorialMessages[0];
                tutorialMessage.SetActive(true);
            }
        }

        if (level == 11)
        {
            giveText = GameObject.Find("Give_Text");
            clickText = GameObject.Find("Click_Text");
            //giveText.SetActive(false);
            //clickText.SetActive(false);

            finalScore = GameObject.Find("Score Display").GetComponent<Text>();
            finalScore.text = "Score: " + quizScore.ToString();

            for (int i = 1; i < 15; i++) 
            {
                PopulateInventory(i);
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(GameManager.currentAction.ToString());	
	}

    public static void UpdateActionText(string text)
    {
        actionText.text = text;
    }

    public static void UpdateDialogueText(string text)
    {
        dialogueText.text = text;
    }

    public static void ChangeCurrentAction(int actionIndex)
    {
        currentAction = actionIndex;
    }

    public static void UpdateInventory(Sprite itemSprite)
    {
        inventorySlots.Add(itemSprite);
        Debug.Log("Added " + itemSprite.name + " to item list");

        //Image imageToBeChanged = inventorySlots[inventory.Count - 1].GetComponent<Image>();
        //imageToBeChanged.sprite = itemSprite;
        //Color c = imageToBeChanged.color;
        //c.a = 1;
        //imageToBeChanged.color = c;
    }

    public static int ParseClick(string name)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (inventorySlots[i].name == name)
            {
                return i;
            }
        }
        return 0;
    }

    public void ContinueTutorial(GameObject tut)
    {
        int index = tutorialMessages.IndexOf(tut);
        tut.SetActive(false);

        if (index == tutorialMessages.Count - 1)
        {
            return;
        } else
        {
            tutorialMessage = tutorialMessages[index + 1];
            tutorialMessage.SetActive(true);
        }
    }

    //clears the inventory
    public void ClearInventory()
    {
        //Debug.Log("Clearing inventory");
        //inventory.Clear();
        //Debug.Log(inventory.Count);
    }

    public void PopulateInventory(int i)
    {
        Image imageToBeChanged = GameObject.Find("Slot_" + i + "_Icon").GetComponent<Image>();
        imageToBeChanged.sprite = GameManager.inventorySlots[i - 1];
        Color c = imageToBeChanged.color;
        c.a = 1;
        imageToBeChanged.color = c;
    }

    public static void ShowItemDescription(Item item)
    {
        clickText.SetActive(true);
        clickText.GetComponentInChildren<Text>().text = item.ItemDescription;
    }

    public static void UpdateWilsonGiveText(Item item)
    {
        giveText.SetActive(true);
        giveText.GetComponentInChildren<Text>().text = item.ValidGive;
    }

    public static void UpdateScore(Item item)
    {
        quizScore += item.Value;
        finalScore.text = "Score: " + quizScore.ToString();
    }
}
