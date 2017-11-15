using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runLeft : MonoBehaviour {
	public float speed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		rb.AddForce(10.0f * Vector2.left);
	}
}
