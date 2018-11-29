/*Missile.cs

This script determines the behavior of the missiles used in the WWI minigame.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missile : MonoBehaviour
{
    //time before the missile is autodestroyed
    public float decay = 2.5f;

    public GameObject hitTextPrefab;

    //constant modifier of speed
    private float speed = 5f;

    private Vector3 pos;
    private Collider2D coll;
    private Boat boat;

	// Use this for initialization
	void Start ()
    {
        //get references to the position of the gameobject this script is attached to
        pos = transform.position;
        //set the parent of the missile
        transform.SetParent(GameObject.Find("background").transform, false);
        //get references to both the boat and the tower's collider
        coll = GameObject.Find("Tower").GetComponent<Collider2D>();
        boat = GameObject.Find("Boat").GetComponent<Boat>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //decrease elapsed time
        decay -= Time.deltaTime;

        //if timer is 0 or below
        if (decay <= 0)
        {
            //destroy missile and reset timer
            Destroy(gameObject);
            decay = 3f;
        }

        //make missile travel along straight horizontal line, smoothed
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the other collider is the tower
        if (other.name == coll.name)
        {
            //decrease the health by the index of the current option
            boat.health -= Boat.currentIndex;
            if (WWIManager.canSpawn)
            {
                GameObject objectToBeInstantiated = Instantiate(hitTextPrefab, GameObject.Find("Tower").transform.position, Quaternion.identity);
                WWIManager.canSpawn = false;
                WWIManager.spawnTimer = 2f;
            }
        }
    }
}
