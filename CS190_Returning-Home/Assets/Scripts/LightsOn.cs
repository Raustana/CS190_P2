using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOn : MonoBehaviour {

    public bool playerHere = false;
    [Tooltip("Sets the time to reset to on run")]
    public float timer = 0;
    float original;

	// Use this for initialization
	void Start () {
        original = timer;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHere)
        {
            this.GetComponent<Light>().enabled = true;
            timer = original;
        }
        else if (timer > 0)
        {
            timer -= Time.deltaTime;
            //Debug.Log("Countdown");
        }

        if(timer <= 0)
        {
            this.GetComponent<Light>().enabled = false;
            timer = 0;
        }
	}
}
