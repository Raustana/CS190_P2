using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAppear : MonoBehaviour {

    [Tooltip("Sets the time to reset to on run")]
    public float timer = 0;
    float interval;
    bool growing = true;

    // Use this for initialization
    void OnEnable () {
        interval = timer;
        timer = 0;
        this.GetComponent<Light>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.GetComponent<Light>().enabled)
        {
            if(growing)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }

            if(timer >= interval)
            {
                growing = false;
            }
            else if (timer <= 0)
            {
                growing = true;
            }

            this.GetComponent<Light>().intensity = 3 * timer / interval;

        }
	}
}
