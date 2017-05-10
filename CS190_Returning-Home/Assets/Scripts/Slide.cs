using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour {

    bool opened = false;
    public bool playerHere = false;
    public float speed = 0.8f;
    Vector3 original;
    bool played = true;
    bool pickedUp = false;

    public GameObject pickup;

	// Use this for initialization
	void Start () {
        original = transform.position;
        pickedUp = false;
    }
	
	// Update is called once per frame
	void Update () {

        //Check if the door was opened, and where it is in relation to its original position.
        if(opened && playerHere)
        {
            transform.Translate(new Vector3(1 * speed * Time.deltaTime, 0, 0));
        }
        if(transform.position.x >= original.x + 1.5)
        {
            opened = false;
        }

        //Check if player is in vicinity, and where the door is in relation to its original position.
        if (!playerHere && transform.position.x > original.x)
        {
            transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
            if(!played)
            {
                if (GetComponent<DoorClose>() != null)
                    GetComponent<DoorClose>().Closing();
                played = true;
            }
        }
        if (transform.position.x < original.x)
        {
            transform.position = original;
        }
	}

    public void Interact ()
    {
        if (playerHere)
            playerHere = false;
        //Only open if the door is not at the end position.
        if (transform.position.x < original.x + 1.5)
        {
            opened = true;
            playerHere = true;
            if (GetComponent<DoorOpen>() != null)
                GetComponent<DoorOpen>().Opening();
            played = false;
        }
        if (!pickedUp && pickup != null)
        {
            pickup.SetActive(true);
            pickedUp = true;
        }
    }
}
