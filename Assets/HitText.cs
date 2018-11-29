using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitText : MonoBehaviour 
{

	//time before the object is autodestroyed
    public float decay = 5f;

	public List<string> hitResponses = new List<string>();

	//constant modifier of speed
    private float speed = 1.5f;
    private Vector3 pos;
    private Text textComponent;

	// Use this for initialization
	void Start () 
	{
		//get references to the position of the gameobject this script is attached to
        pos = transform.position;
        //set the parent of the missile
        transform.SetParent(GameObject.Find("Tower").transform, false);
        textComponent = GetComponent<Text>();
        textComponent.text = hitResponses[Random.Range(0,6)];	
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
            decay = 5f;
        }

        //make missile travel along straight horizontal line, smoothed
        pos.y += speed * Time.deltaTime;
        transform.position = pos;	
	}
}
