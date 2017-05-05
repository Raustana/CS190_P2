using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    public GameObject player;
    public GameObject sun;
    public GameObject ambient;

    public float timer = 13;
    bool canMove;

    Color shade;

	// Use this for initialization
	void Start () {
        canMove = false;
        
        shade = this.GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
        if(timer > -3)
            timer -= Time.deltaTime;

        if (timer < 1)
            canMove = true;

        if (timer < 5)
        {
            sun.SetActive(true);
            ambient.SetActive(true);
            if (timer <= 0)
                shade = new Color(shade.r, shade.g, shade.b, 0);
            else
                shade = new Color(shade.r, shade.g, shade.b, timer / 5);
            this.GetComponent<Renderer>().material.color = shade;
        }

        if (timer < 10)
            player.SetActive(true);

        if (canMove)
        {
            player.GetComponent<PlayerMove>().enabled = true;
        }


	}
}
