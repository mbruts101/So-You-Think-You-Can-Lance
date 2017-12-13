using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class boatScript : MonoBehaviour {
	public bool boatActive = false;
	public Transform boatEnd;
	public int speed;

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
			GameObject g = GameObject.Find ("Sir Lance");
			g.GetComponent<PlatformerCharacter2D> ().maxSpeed = 0;
			g.GetComponent<PlatformerCharacter2D> ().inCutscene = true;
			StartCoroutine (wait ());
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(.2f);
		GameObject g = GameObject.Find ("Sir Lance");
		g.GetComponent<Animator> ().enabled = false;
		g.transform.parent = this.transform;
		this.transform.position = Vector3.MoveTowards (this.transform.position, boatEnd.transform.position, speed * Time.deltaTime);


	}
}
