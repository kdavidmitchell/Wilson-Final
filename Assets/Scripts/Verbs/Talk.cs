using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Verbs/Talk")]
public class Talk : InputVerb
{

    public override void RespondToChoice()
    {
        //change current action
        GameManager.ChangeCurrentAction(3);

        GameManager.UpdateActionText(GameManager.verbs[3].actionText);

        GameManager.dialogueText.fontStyle = FontStyle.Normal;
    }

    
}
