using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSpawn : MonoBehaviour {

//Daniel Cole
//1870787
//cole149@mail.chapman.edu
//Level Design II 344
//So You Think You Can Lance
//

	public GameObject g;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		g.AddComponent<Rigidbody2D> ();
	}
}
