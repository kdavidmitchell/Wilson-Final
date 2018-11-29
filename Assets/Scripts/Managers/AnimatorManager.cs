/*AnimatorManager.cs

This script manages the animator component of the gameobject to which this script is attached. It also exposes
much needed functionality to other classes.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    //animator of the gameobject that has this script
    private Animator animator;
    //AnimatorManagers of other gameobjects in the scene
    private List<AnimatorManager> others = new List<AnimatorManager>();

	// Use this for initialization
	void Start ()
    {
        //first, get this gameobject's animator component
        animator = GetComponent<Animator>();

        //find all people in the scene
        GameObject[] people = GameObject.FindGameObjectsWithTag("Person");
        for (int i = 0; i < people.Length; i++)
        {
            //for the number of people in the scene, if the person does not match this gameobject
            if (people[i] != gameObject)
            {
                //add those people's AnimatorManagers to the others list
                others.Add(people[i].GetComponent<AnimatorManager>());
            }
        }

        //make sure to set everything to idle on start
        ResetToIdle();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /*This function exposes the talk functionality to outside classes by setting
    all other people to idle and making the clicked individual start the speaking animation.*/
    public void Talk()
    {
        foreach (AnimatorManager anim in others)
        {
            anim.ResetToIdle();
        }

        animator.SetBool("isTalking", true);
        animator.SetBool("isIdle", false);
    }

    /*This function exposes the reset to idle functionality to outside classes.*/
    public void ResetToIdle()
    {
        animator.SetBool("isIdle", true);
        animator.SetBool("isTalking", false);
    }
}
