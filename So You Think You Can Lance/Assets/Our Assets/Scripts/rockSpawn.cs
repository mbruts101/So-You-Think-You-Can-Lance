using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSpawn : MonoBehaviour {

	public GameObject g;
	public bool isRolling = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") 
		{
			if (isRolling) {
				g.GetComponent<runLeft> ().enabled = true;
				//g.GetComponent<rotate> ().enabled = true;
			} else {
				g.AddComponent<Rigidbody2D> ();
			}
		}
	}
}
