using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeTeleport : MonoBehaviour {

	public GameObject g;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		Debug.Log ("TELEPORT");
		c.gameObject.transform.position = g.transform.position;
	}
}
