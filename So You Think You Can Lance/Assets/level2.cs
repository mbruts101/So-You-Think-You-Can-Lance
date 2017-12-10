using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level2 : MonoBehaviour {
	public GameObject center;

	// Use this for initialization

	void Start () {
		center.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
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
		center.GetComponent<Image> ().CrossFadeAlpha (1f, 2f, true);
		yield return new WaitForSeconds (2f);
		Application.LoadLevel ("Level2");
	}


		
	
}
