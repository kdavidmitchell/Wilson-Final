/*
PeopleDB.cs

This script is designed to be dragged onto a GameObject that holds data for all people found within the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System;

public class PeopleDB : MonoBehaviour
{

    private Dictionary<string, string> peopleDictionary = new Dictionary<string, string>();
    private List<Dictionary<string, string>> peopleDictionaries = new List<Dictionary<string, string>>();

    public TextAsset peopleDatabase;
    public static List<Person> people = new List<Person>();
    public static PeopleDB instance = null;

    private void Awake()
    {
        //if there are any other instances of PeopleDB in a scene, destroy them and make this the only one
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        //begin reading people from the XML sheet
        ReadItemsFromDatabase();

        //debug tools -- turn every person in the newly made dictionary into a Person class
        for (int i = 0; i < peopleDictionaries.Count; i++)
        {
            people.Add(new Person(peopleDictionaries[i]));

            foreach (Person person in people)
            {
                
            }
        }

        //make this database persist throughout the game
        DontDestroyOnLoad(gameObject);
    }

    private void ReadItemsFromDatabase()
    {
        //load XML document
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(peopleDatabase.text);
        //find each singular person in the XML sheet by tag
        XmlNodeList peopleList = xmlDocument.GetElementsByTagName("Person");

        //get the nodes within each "person"
        foreach (XmlNode peopleInfo in peopleList)
        {
            XmlNodeList peopleContent = peopleInfo.ChildNodes;
            peopleDictionary = new Dictionary<string, string>();

            //find all of the below content nodes and store both the name of the node and its value as strings into a singular person dictionary
            foreach (XmlNode content in peopleContent)
            {
                switch (content.Name)
                {
                    case "Name":
                        peopleDictionary.Add("Name", content.InnerText);
                        break;
                    case "ID":
                        peopleDictionary.Add("ID", content.InnerText);
                        break;
                    case "Look":
                        peopleDictionary.Add("Look", content.InnerText);
                        break;
                    case "Talk0":
                        peopleDictionary.Add("Talk0", content.InnerText);
                        break;
                    case "Talk1":
                        peopleDictionary.Add("Talk1", content.InnerText);
                        break;
                    case "Question0":
                        peopleDictionary.Add("Question0", content.InnerText);
                        break;
                    case "Question1":
                        peopleDictionary.Add("Question1", content.InnerText);
                        break;
                    case "Answer0":
                        peopleDictionary.Add("Answer0", content.InnerText);
                        break;
                    case "Answer1":
                        peopleDictionary.Add("Answer1", content.InnerText);
                        break;
                }
            }
            //add the singular person dictionary to a larger list containing all people dictionaries
            peopleDictionaries.Add(peopleDictionary);
        }
    }
}
