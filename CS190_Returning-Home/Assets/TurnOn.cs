using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour {

    public Light monitor;
    public GameObject screen;
    bool onoff = false;
    public float rate;
    public float max;
    float changing = 0;
    Color shade;

	// Use this for initialization
	void Start () {
        changing = 0;
        shade = screen.GetComponent<Renderer>().material.color;
        shade = new Color(shade.r, shade.g, shade.b, 0);
        screen.GetComponent<Renderer>().material.color = shade;
    }

    // Update is called once per frame
    void Update() {
        if (onoff)
        {
            monitor.enabled = true;
            if (monitor.intensity < max)
            {
                monitor.intensity += rate * Time.deltaTime;
            }
            if (monitor.intensity > max)
            {
                monitor.intensity = max;
            }
            changing = monitor.intensity / max;
            shade = new Color(shade.r, shade.g, shade.b, changing);
            screen.GetComponent<Renderer>().material.color = shade;
        }
        else
        {
            if (monitor.intensity > 0)
            {
                monitor.intensity -= rate * 2 * Time.deltaTime;
            }
            else
            {
                monitor.intensity = 0;
            }
            changing = monitor.intensity / max;
            shade = new Color(shade.r, shade.g, shade.b, changing);
            screen.GetComponent<Renderer>().material.color = shade;
        }

	}

    public void Interact()
    {
        if (onoff)
        {
            onoff = false;
            monitor.enabled = false;
        }
        else
            onoff = true;
    }
}
