using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour {

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
			Debug.Log ("SHIELD YAAAAA");
			StartCoroutine (spin ());
		}
	}

	IEnumerator spin()
	{
		GameObject g = GameObject.Find ("Lance");
		for (int i = 0; i < 360; i++) 
		{
			yield return new WaitForSeconds (.1f);
			g.transform.parent = null;
			g.transform.localRotation = Quaternion.Euler (0, 0, i);
		}
	}
}
