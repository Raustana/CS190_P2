using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
        transform.position = player.transform.position + new Vector3(0, 7, -4);
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = player.transform.position + new Vector3(0, 7, -4);

    }
}
