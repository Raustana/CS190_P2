using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;
    float timer;

	// Use this for initialization
	void Start () {
        transform.position = player.transform.position + new Vector3(0, 7, -4);
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = player.transform.position + new Vector3(0, 7, -4);
        timer += Time.deltaTime;
        if(timer >= 3 + player.GetComponent<PlayerMove>().pickups)
        {
            GetComponent<_PickupPing>().Pinging();
            timer = 0;
        }

    }
}
