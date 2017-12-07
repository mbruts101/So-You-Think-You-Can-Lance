using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2 : MonoBehaviour {
	public GameObject center;

	// Use this for initialization

	void Start () {
		center = GameObject.Find ("FadeBlack");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			Application.LoadLevel("Level2");
		}
	}


		
	
}
