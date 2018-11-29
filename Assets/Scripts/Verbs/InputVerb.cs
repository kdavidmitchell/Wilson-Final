using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputVerb : ScriptableObject
{

    public string verb;
    public string actionText;

    public abstract void RespondToChoice();
}
