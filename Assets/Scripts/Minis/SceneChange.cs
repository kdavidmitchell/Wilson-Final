/*SceneChange.cs

A simple script used to transition between two scenes.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the gameobject this script is attached to collides with Wilson
        if (other.name == "Wilson")
        {
            //start the coroutine
            StartCoroutine(Delay());
        }
    }

    //A coroutine that delays the loading of a scene.
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("WhiteHouse_1");
    }
}
