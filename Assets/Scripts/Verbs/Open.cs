using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Verbs/Open")]
public class Open : InputVerb
{

	public override void RespondToChoice()
    {
        //change current action
        GameManager.ChangeCurrentAction(1);

        GameManager.UpdateActionText(GameManager.verbs[1].actionText);
        //1. get object clicked on
        //2. if door - transition scene
        //3. if not - return
    }
}
