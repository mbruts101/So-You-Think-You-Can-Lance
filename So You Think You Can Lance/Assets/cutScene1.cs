using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class cutScene1 : MonoBehaviour {
	public GameObject lance;
	public GameObject hand;

	private Vector3 endPosition;

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

			col.gameObject.GetComponent<Animator> ().enabled = false;
			GameObject.Find ("SirLance").GetComponent<PlatformerCharacter2D> ().inCutscene = true;

			GameObject bandit = GameObject.Find ("BanditTurn");
			bandit.transform.localRotation = Quaternion.Euler(0, 180, 0);
			Transform temp = lance.transform;
			bandit.transform.DetachChildren ();
			lance.transform.position = temp.transform.position;
			//lance.transform.position = new Vector2 (100, 100);
			//GameObject.Find ("BanditTurn").transform.DetachChildren ();
			//lance.transform.parent = GameObject.Find("Hand").transform;

		

			//lance.transform.position = endPosition;

			//GameObject.Find ("SirLance").GetComponent<PlatformerCharacter2D> ().inCutscene = false;
		}
	}
		
}
