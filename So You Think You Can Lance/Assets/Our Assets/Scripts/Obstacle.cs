//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public bool isProjectile = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
		if(col.gameObject.tag == "Stabbable")
        {
            Destroy(col.gameObject);
        }

		if (col.gameObject.tag == "Player" && isProjectile  == false) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Destroy(col.gameObject);
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
