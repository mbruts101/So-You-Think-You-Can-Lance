using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startLevel : MonoBehaviour {

	public GameObject center;

	void Start () 
	{
		StartCoroutine (fade ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator fade()
	{
		yield return new WaitForSeconds (.6f);
		center.GetComponent<Image> ().CrossFadeAlpha (0f, 5f, true);
	}

}
