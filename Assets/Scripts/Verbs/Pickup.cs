using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Verbs/Pickup")]
public class Pickup : InputVerb
{

    public override void RespondToChoice()
    {
        //change current action
        GameManager.ChangeCurrentAction(4);
        GameManager.UpdateActionText(GameManager.verbs[4].actionText);
    }
}
