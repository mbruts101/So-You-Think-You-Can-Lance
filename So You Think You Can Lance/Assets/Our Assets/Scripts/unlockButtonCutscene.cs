using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class unlockButtonCutscene : MonoBehaviour {
	private bool pressed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && pressed == false) 
		{
			pressed = true;
			GameObject.Find ("Sir Lance").GetComponent<PlatformerCharacter2D> ().inCutscene = true;
			Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D> ();
			rb.constraints = RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;
			col.gameObject.GetComponent<Animator> ().enabled = false;
		}
	}
}
