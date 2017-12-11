using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class buttonPress : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Lance") 
		{
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + .25f, 0f);
			StartCoroutine (walk ());
		}
	}

	IEnumerator walk()
	{	
		yield return new WaitForSeconds (1f);
		GameObject door = GameObject.Find ("Door");
		for (float i = 0f; i < 3f; i += .25f)
		{
			yield return new WaitForSeconds (.5f);
			door.transform.position = new Vector3 (door.transform.position.x, door.transform.position.y - i, 0f);
		}
		yield return new WaitForSeconds (3f);
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - .25f, 0f);

		GameObject g = GameObject.Find ("Sir Lance");
		Rigidbody2D rb = g.GetComponent<Rigidbody2D> ();

		rb.constraints = RigidbodyConstraints2D.FreezeRotation;

		g.GetComponent<Animator> ().enabled = true;
		g.GetComponent<PlatformerCharacter2D> ().inCutscene = false;
	}
}
