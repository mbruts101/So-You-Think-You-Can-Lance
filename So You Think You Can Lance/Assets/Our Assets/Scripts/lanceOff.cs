using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanceOff : MonoBehaviour {
	public GameObject g;
	public bool activate;
	public GameObject top;
	public GameObject bottom;

	// Use this for initialization
	void Start () {
		top = GameObject.Find ("TopBlack");
		bottom = GameObject.Find ("BottomBlack");
		g = GameObject.Find ("SirLance");
		StartCoroutine (cinema ());
		g.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (activate)
		{
			StartCoroutine (cinemaOff ());
			g.SetActive (true);
		}
	}

	IEnumerator cinema()
	{
		float scaleY = 1.55f;
		while (scaleY < 2.5) 
		{
			yield return new WaitForSeconds (.0001f);
			top.transform.localScale = new Vector3 (103, scaleY, 0);
			bottom.transform.localScale = new Vector3 (103, scaleY, 0);
			scaleY += .02f;
		}
	}

	IEnumerator cinemaOff()
	{
		float scaleY = 2.5f;
		while (scaleY > 1.55) 
		{
			yield return new WaitForSeconds (.0001f);
			top.transform.localScale = new Vector3 (103, scaleY, 0);
			bottom.transform.localScale = new Vector3 (103, scaleY, 0);
			scaleY -= .02f;
		}
	}
}
