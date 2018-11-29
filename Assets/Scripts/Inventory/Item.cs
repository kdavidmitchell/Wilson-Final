/*Item.cs

This script is a data class meant to define an item within the game.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //assign all the values we want to give every item in the game
    private string _name;
    private int _ID;
    //a string response to using the "look" action in the game
    private string _description;
    //bool that determines if an item can be picked up
    private bool _isInventoryItem;
    //string responses from handing over an item that either can or cant be given to Wilson
    private string _validGive;
    private string _invalidGive;
    //string that gives the score value of the item
    private int _value;

    //constructor that builds an Item based on a Dictionary<string,string> created by ItemDB
    public Item(Dictionary<string, string> itemDictionary)
    {
        _name = itemDictionary["Name"];
        _ID = int.Parse(itemDictionary["ID"]);
        _description = itemDictionary["Description"];
        _isInventoryItem = bool.Parse(itemDictionary["IsInventoryItem"]);
        _validGive = itemDictionary["ValidGive"];
        _invalidGive = itemDictionary["InvalidGive"];
        _value = int.Parse(itemDictionary["Value"]);
    }

    //default constructor
    public Item()
    {
        _name = "Default";
        _ID = 1000;
        _description = "Default";
        _isInventoryItem = false;
        _validGive = "Default";
        _invalidGive = "Default";
        _value = 0;
    }

    //settable and gettable properties of Item
    public string ItemName
    {
        get { return _name; }
        set { _name = value; }
    }

    public int ItemID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    public string ItemDescription
    {
        get { return _description; }
        set { _description = value; }
    }

    public bool IsInventoryItem
    {
        get { return _isInventoryItem; }
        set { _isInventoryItem = value; }
    }

    public string ValidGive
    {
        get { return _validGive; }
        set { _validGive = value; }
    }

    public string InvalidGive
    {
        get { return _invalidGive; }
        set { _invalidGive = value; }
    }

    public int Value
    {
        get { return _value; }
        set {_value = value; }
    }
}
