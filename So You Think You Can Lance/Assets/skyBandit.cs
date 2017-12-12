using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyBandit : MonoBehaviour {
	public bool drop = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (drop) 
		{
			Destroy (this.GetComponent<CircleCollider2D> ());
			this.GetComponent<SpriteRenderer> ().flipX = true;
			this.gameObject.GetComponent<runLeft> ().enabled = false;

			this.gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
	}
}
