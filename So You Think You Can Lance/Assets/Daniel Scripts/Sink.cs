using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Daniel Cole
//1870787
//cole149@mail.chapman.edu
//Level Design II 344
//So You Think You Can Lance
//
public class Sink : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		Debug.Log ("SINK");
	}

	void OnTriggerStay2D(Collider2D c)
	{
		this.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y - .025f);
	}
}
