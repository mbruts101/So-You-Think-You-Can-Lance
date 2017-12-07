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
			StartCoroutine (fade ());

		}
	}

	IEnumerator fade()
	{
		float scaleY = 0;
		while (scaleY < 1) 
		{
			yield return new WaitForSeconds (.0001f);
			var col = center.GetComponent<Renderer> ().material.color;
			col.a += scaleY;
			scaleY += .05f;
		}
		Application.LoadLevel("Level2");
	}
}
