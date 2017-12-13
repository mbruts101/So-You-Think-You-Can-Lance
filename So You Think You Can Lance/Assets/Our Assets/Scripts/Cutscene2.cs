using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class Cutscene2 : MonoBehaviour {

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
			col.gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX;
			col.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
			GameObject.Find("SirLance").GetComponent<Animator> ().enabled = false;
			GameObject.Find ("SirLance").GetComponent<PlatformerCharacter2D> ().inCutscene = true;
		}
	}
}
