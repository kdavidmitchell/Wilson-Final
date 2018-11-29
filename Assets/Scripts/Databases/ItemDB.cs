/*
ItemDB.cs

This script is designed to be dragged onto a GameObject that holds data for all items found within the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class ItemDB : MonoBehaviour
{
    private Dictionary<string, string> itemDictionary = new Dictionary<string, string>();
    private List<Dictionary<string, string>> itemDictionaries = new List<Dictionary<string, string>>();

    public TextAsset itemDatabase;
    public static List<Item> items = new List<Item>();

    public static ItemDB instance = null;

    private void Awake()
    {
    	//if there are any other instances of ItemDB in a scene, destroy them and make this the only one
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        //begin reading items from the XML sheet
        ReadItemsFromDatabase();

        //debug tools -- turn every item in the newly made dictionary into an Item class
        for (int i = 0; i < itemDictionaries.Count; i++)
        {
            items.Add(new Item(itemDictionaries[i]));

            foreach (Item item in items)
            {
                //Debug.Log(item.ItemName);
                //Debug.Log(item.ItemID.ToString());
                //Debug.Log(item.ItemDescription);
                //Debug.Log(item.IsInventoryItem);
            }
        }

        //make this database persist throughout the game
        DontDestroyOnLoad(gameObject);
    }

    //A function designed to read from an XML sheet with tags that describe the various items in the game.
    private void ReadItemsFromDatabase()
    {
    	//load the XML document
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(itemDatabase.text);
        //find each singular item in the XML sheet by tag
        XmlNodeList itemList = xmlDocument.GetElementsByTagName("Item");

        //get the nodes within each "item"
        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            itemDictionary = new Dictionary<string, string>();

            //find all of the below content nodes and store both the name of the node and its value as strings into a singular item dictionary
            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "Name":
                        itemDictionary.Add("Name", content.InnerText);
                        break;
                    case "ID":
                        itemDictionary.Add("ID", content.InnerText);
                        break;
                    case "Description":
                        itemDictionary.Add("Description", content.InnerText);
                        break;
                    case "IsInventoryItem":
                        itemDictionary.Add("IsInventoryItem", content.InnerText);
                        break;
                    case "IsDraggable":
                        itemDictionary.Add("IsDraggable", content.InnerText);
                        break;
                    case "ValidGive":
                        itemDictionary.Add("ValidGive", content.InnerText);
                        break;
                    case "InvalidGive":
                        itemDictionary.Add("InvalidGive", content.InnerText);
                        break;
                    case "Value":
                        itemDictionary.Add("Value", content.InnerText);
                        break;
                }
            }
            //add the singular item dictionary to a larger list containing all item dictionaries
            itemDictionaries.Add(itemDictionary);
        }


    }
}
