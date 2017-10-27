//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {
	public AudioSource chickenDeath;
	// Use this for initialization
	void Start () {
		AudioSource[] audios = GetComponents<AudioSource>();
		chickenDeath = audios[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Chicken") {
			if (col.gameObject.tag == "Chicken") {
				chickenDeath.Play ();
			}

			Destroy (col.gameObject);
		} 
		else if (col.gameObject.tag == "Stabbable")
		{
			Destroy (col.gameObject);
		}
    }
}
