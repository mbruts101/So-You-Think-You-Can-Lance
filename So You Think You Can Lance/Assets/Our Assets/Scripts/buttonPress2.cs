using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonPress2 : MonoBehaviour {
	public GameObject center;

	// Use this for initialization
	void Start () {
		center = GameObject.Find ("Center");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Lance") 
		{
			this.transform.position = new Vector3 (this.transform.position.x + .25f, this.transform.position.y, 0f);
			GameObject g = GameObject.Find ("Platform");
			StartCoroutine (raise ());
		}
	}

	IEnumerator raise()
	{
		GameObject g = GameObject.Find ("Platform");
		Vector3 temp = g.transform.position;
		for (float i = 0; i <= 1; i += .008f) 
		{
			yield return new WaitForSeconds (.05f);
			if (i > .25)
			{
				center.GetComponent<Image> ().CrossFadeAlpha (1f, 2f, true);
			}
			g.transform.position = Vector3.Lerp (temp, temp + new Vector3 (0f, 15f, 0f), i);
			if (i > .65)
			{
				SceneManager.LoadScene ("BossFight");
			}
		}
	}
}
