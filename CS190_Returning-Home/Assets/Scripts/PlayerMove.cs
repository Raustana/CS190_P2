using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 6.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public int pickups;

    // Use this for initialization
    void Start()
    {
        pickups = 0;
    }

    // Update is called once per frame
    void Update () {
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "Pickup")
        {
            Destroy(hit.gameObject);
            pickups += 1;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.name == "RoomLight")
        {
            other.gameObject.GetComponent<LightsOn>().playerHere = true;
        }
    }

    void OnTriggerStay (Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Interactive") && Input.GetKeyDown("e"))
        {
            if(other.gameObject.name == "GlassWall")
            {
                other.gameObject.GetComponent<Slide>().Interact();
            }
            if (other.gameObject.name == "Hinge")
            {
                other.gameObject.GetComponent<Open>().Interact();
            }
            if (other.gameObject.name == "Desk" || other.gameObject.name == "TV")
            {
                other.gameObject.GetComponent<TurnOn>().Interact();
            }
            //Debug.Log("Interacting");
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactive"))
        {
            if (other.gameObject.name == "RoomLight")
            {
                other.gameObject.GetComponent<LightsOn>().playerHere = false;
            }
            if (other.gameObject.name == "GlassWall")
            {
                other.gameObject.GetComponent<Slide>().playerHere = false;
            }
            if (other.gameObject.name == "Hinge")
            {
                other.gameObject.GetComponent<Open>().playerHere = false;
            }
        }
        //Debug.Log("Player Leaving");
    }
}
