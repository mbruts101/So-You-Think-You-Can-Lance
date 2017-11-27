using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutScene1 : MonoBehaviour {
	public GameObject lance; 
	public GameObject bandit2;
	// Use this for initialization
	void Start () {
		bandit2 = GameObject.Find ("Bandit2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			col.gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX;

			col.gameObject.GetComponent<Animator> ().enabled = false;

			Debug.Log ("CUT SCENE");
			bandit2.GetComponent<SpriteRenderer> ().flipX = true;
		}
	}
}
