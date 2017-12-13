using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateRock : MonoBehaviour {
	public GameObject g;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			g.GetComponent<rockMo> ().enabled = true;
		}
	}
}
