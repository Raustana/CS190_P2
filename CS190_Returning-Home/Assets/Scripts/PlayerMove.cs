using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 6.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public int pickups;
    public string groundType;
    float timeSinceStep = 0;

    // Use this for initialization
    void Start()
    {
        pickups = 0;
        groundType = "Concrete";
        timeSinceStep = 0;
    }

    // Update is called once per frame
    void Update () {
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (moveDirection.x > 0 || moveDirection.z > 0 || moveDirection.x < 0 || moveDirection.z < 0)
        {
            if (timeSinceStep > 0.5)
            {
                GetComponent<_Footsteps>().Step();
                timeSinceStep = 0;
            }
            timeSinceStep += Time.deltaTime;
        }
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    // Check floor type (courtesy of http://answers.unity3d.com/questions/266673/footsteps-on-different-surfaces.html )
    // Floor types are: 1, Concrete; 2, Carpet; 3, Tile; 4, Grass
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.transform.position.y < this.gameObject.transform.position.y)
        {
            if (hit.gameObject.tag == "Concrete")
            {
                groundType = "Concrete";
                GetComponent<Footstep_Concrete>().FootstepConcrete();
            }
            else if (hit.gameObject.tag == "Carpet")
            {
                groundType = "Carpet";
                GetComponent<Footstep_Carpet>().FootstepCarpet();
            }
            else if (hit.gameObject.tag == "Tile")
            {
                groundType = "Tile";
                GetComponent<Footstep_Tile>().FootstepTile();
            }
            else if (hit.gameObject.tag == "Grass")
            {
                groundType = "Grass";
                GetComponent<Footstep_Grass>().FootstepGrass();
            }
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.name == "RoomLight")
        {
            other.gameObject.GetComponent<LightsOn>().playerHere = true;
        }
        if (other.gameObject.name == "Pickup")
        {
            other.gameObject.SetActive(false);
            pickups += 1;
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
