using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Verbs/Look")]
public class Look : InputVerb
{
    public GUIText fontstyle;

	public override void RespondToChoice()
    {
        //change current action
        GameManager.ChangeCurrentAction(2);

        //1. change dialogue text to description of object clicked on and action text
        GameManager.UpdateActionText(GameManager.verbs[2].actionText);

        //2. font to italics
        GameManager.dialogueText.fontStyle = FontStyle.Italic;
    }
}
