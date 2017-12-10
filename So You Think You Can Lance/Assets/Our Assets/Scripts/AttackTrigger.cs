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
		if (col.gameObject.tag == "Stabbable")
		{
			chickenDeath.Play ();
			col.enabled = false;
			StartCoroutine (Stab(col));
			//col.gameObject.transform.SetParent(v.transform);
			chickenDeath.Play ();
		}
    }

	IEnumerator Stab(Collider2D col) 
	{
		yield return new WaitForSeconds (.05f);
		var v = GameObject.Find ("LanceEmpty");
		Destroy (col.gameObject.GetComponent<Rigidbody2D> ());
        if(col.gameObject.name == "Egg(Clone")
        {
            col.gameObject.GetComponent<Animator>().enabled = false;
            col.gameObject.GetComponent<runLeft>().enabled = false;
        }
		col.gameObject.transform.SetParent(v.transform);
		col.gameObject.GetComponent<Projectile> ().enabled = true;
	}
}
