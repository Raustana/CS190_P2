using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {

    bool opened = false;
    public bool playerHere = false;
    public float speed = 10f;
    public float max;
    public float timer = 0;
    Quaternion original;
    bool played = true;
    bool pickedUp = false;

    public GameObject pickup;

    // Use this for initialization
    void Start () {
        original = transform.rotation;
        pickedUp = false;
        //Debug.Log(original[1] + max);
    }
	
	// Update is called once per frame
	void Update () {

        //Check if the door was opened and if the player is present. This opens the door.
        if (opened && playerHere)
        {
            transform.Rotate(new Vector3(0, 1 * speed * Time.deltaTime, 0));
            //Debug.Log(Quaternion.Angle(transform.rotation, original));
        }
        //Prevents the door from going further than the maximum.
        if (Quaternion.Angle(transform.rotation, original) >= original[1] + max)
        {
            opened = false;
        }

        //Check if player is in vicinity, and where the door is in relation to its original position. This closes the door.
        if (!playerHere && Quaternion.Angle(transform.rotation, original) > original[1])
        {
            transform.Rotate(new Vector3(0, -1 * speed * Time.deltaTime, 0));
            timer -= Time.deltaTime;
            //Debug.Log(Quaternion.Angle(transform.rotation, original));
        }
        //Checks if the player has left the vicinity, and if the door has closed. This resets the door.
        if (!playerHere && Quaternion.Angle(transform.rotation, original) <= 1 || timer < 0)
        {
            transform.rotation = original;
            timer = 0;
            if (!played)
            {
                if(GetComponent<DoorClose>() != null)
                    GetComponent<DoorClose>().Closing();
                played = true;
            }
        }

    }

    public void Interact()
    {
        if (playerHere)
        {
            playerHere = false;
        }
        // Only rotate if door is not at the maximum position.
        else if (Quaternion.Angle(transform.rotation, original) < original[1] + max)
        {
            opened = true;
            playerHere = true;
            timer = 5;
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
