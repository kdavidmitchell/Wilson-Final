/*Person.cs

This script is a data class meant to define a person within the game.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    //assign all the values we want to give every person in the game
    private string _name;
    private int _ID;
    //a string response to using the "look" action in the game
    private string _look;
    //string responses from simply clicking on people in the game
    private string _talk0;
    private string _talk1;
    //questions that the player can ask this person
    private string _question0;
    private string _question1;
    //answers to the player's previous question (by order)
    private string _answer0;
    private string _answer1;

    //constructor that creates a Person based on a Dictionary<string,string> created by PeopleDB
    public Person(Dictionary<string, string> peopleDictionary)
    {
        _name = peopleDictionary["Name"];
        _ID = int.Parse(peopleDictionary["ID"]);
        _look = peopleDictionary["Look"];
        _talk0 = peopleDictionary["Talk0"];
        _talk1 = peopleDictionary["Talk1"];
        _question0 = peopleDictionary["Question0"];
        _question1 = peopleDictionary["Question1"];
        _answer0 = peopleDictionary["Answer0"];
        _answer1 = peopleDictionary["Answer1"];
    }

    //default constructor
    public Person()
    {
        _name = "Default";
        _ID = 1000;
        _look = "Default";
        _talk0 = "Default";
        _talk1 = "Default";
        _question0 = "Default";
        _question1 = "Default";
        _answer0 = "Default";
        _answer1 = "Default";
    }

    //settable and gettable properties of Person
    public string PersonName
    {
        get { return _name; }
        set { _name = value; }
    }

    public int PersonID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    public string PersonLook
    {
        get { return _look; }
        set { _look = value; }
    }

    public string PersonTalk0
    {
        get { return _talk0; }
        set { _talk0 = value; }
    }

    public string PersonTalk1
    {
        get { return _talk1; }
        set { _talk1 = value; }
    }

    public string PersonQuestion0
    {
        get { return _question0; }
        set { _question0 = value; }
    }

    public string PersonQuestion1
    {
        get { return _question1; }
        set { _question1 = value; }
    }

    public string PersonAnswer0
    {
        get { return _answer0; }
        set { _answer0 = value; }
    }

    public string PersonAnswer1
    {
        get { return _answer1; }
        set { _answer1 = value; }
    }
}
