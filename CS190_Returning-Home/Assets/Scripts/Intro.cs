using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    public GameObject player;
    public GameObject sun;
    public GameObject ambient;
    public Canvas title;

    public float timer = 13;
    bool canMove;

    Color shade;

	// Use this for initialization
	void Start () {
        canMove = false;

        this.GetComponent<Renderer>().enabled = true;
        shade = this.GetComponent<Renderer>().material.color;

        title.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(timer > -3)
            timer -= Time.deltaTime;

        if (timer < 1)
        {
            canMove = true;
            shade = new Color(shade.r, shade.g, shade.b, 0);
            this.GetComponent<Renderer>().material.color = shade;
            this.GetComponent<Renderer>().enabled = false;
        }

        else if (timer < 5)
        {
            title.enabled = false;
            sun.SetActive(true);
            ambient.SetActive(true);
            shade = new Color(shade.r, shade.g, shade.b, timer / 5);
            this.GetComponent<Renderer>().material.color = shade;
        }

        else if (timer < 9.5)
        {
            title.enabled = true;
        }

        else if (timer < 10)
        {
            player.SetActive(true);
        }

        if (canMove)
        {
            player.GetComponent<PlayerMove>().enabled = true;
        }


	}
}
