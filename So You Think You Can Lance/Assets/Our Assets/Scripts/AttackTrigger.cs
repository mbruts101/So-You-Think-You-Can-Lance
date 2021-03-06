﻿
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
		if (col.gameObject.tag == "Shield") 
		{
			Destroy (this.gameObject);
		}

		if (col.gameObject.tag == "Stabbable")
		{
			if (col.gameObject.transform.childCount == 0) 
			{
				chickenDeath.Play ();
				col.enabled = false;
				StartCoroutine (Stab (col));
				//col.gameObject.transform.SetParent(v.transform);
				chickenDeath.Play ();
			}
		}
    }

	IEnumerator Stab(Collider2D col) 
	{
		yield return new WaitForSeconds (.05f);
		var v = GameObject.Find ("LanceEmpty");
		Destroy (col.gameObject.GetComponent<Rigidbody2D> ());
		Destroy (col.gameObject.GetComponent <BoxCollider2D>());
		col.gameObject.transform.SetParent(v.transform);
		col.gameObject.GetComponent<Projectile> ().enabled = true;
		col.gameObject.GetComponent<Obstacle> ().enabled = false;
		Debug.Log ("STAB:" + col.gameObject.name);
		if(col.gameObject.name != "Egg(Clone)")
		{
			col.gameObject.GetComponent<Animator>().enabled = false;
			col.gameObject.GetComponent<runLeft>().enabled = false;
		}
	}
}
