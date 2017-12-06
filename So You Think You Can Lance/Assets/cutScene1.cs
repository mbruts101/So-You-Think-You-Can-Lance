using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class cutScene1 : MonoBehaviour {
	public GameObject lance;
	public GameObject hand;

	public GameObject top;
	public GameObject bottom;

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
			StartCoroutine (cinematicViewOn ());
			col.gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX;
			col.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
			col.gameObject.GetComponent<Animator> ().enabled = false;
			GameObject.Find ("SirLance").GetComponent<PlatformerCharacter2D> ().inCutscene = true;


	


			//lance.transform.position = temp.transform.position;
			//lance.transform.position = new Vector2 (100, 100);
			//GameObject.Find ("BanditTurn").transform.DetachChildren ();
			//lance.transform.parent = GameObject.Find("Hand").transform;

		

			//lance.transform.position = endPosition;

			//GameObject.Find ("SirLance").GetComponent<PlatformerCharacter2D> ().inCutscene = false;
		}
	}

	public void cutScene()
	{
		GameObject bandit = GameObject.Find ("BanditTurn");
		bandit.transform.localRotation = Quaternion.Euler(0, 180, 0);
		bandit.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0,100));
	}

	IEnumerator cinematicViewOn()
	{
		float scaleY = 1.55f;
		while (scaleY < 3) 
		{
			yield return new WaitForSeconds (.0001f);
			top.transform.localScale = new Vector3 (103, scaleY, 0);
			bottom.transform.localScale = new Vector3 (103, scaleY, 0);
			scaleY += .02f;
		}
		GameObject bandit = GameObject.Find ("BanditTurn");
		bandit.transform.localRotation = Quaternion.Euler(0, 180, 0);
		yield return new WaitForSeconds (1);
		bandit.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0,100));
		bandit.transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(-10,10));
		yield return new WaitForSeconds (1.5f);




		GameObject g = GameObject.Find ("Chicken");
		g.transform.localRotation = Quaternion.Euler(0, 180, 0);
		Vector3 tempVector = g.transform.position;
		for (float i = 0f; i < 1f; i+= .01f)
		{
			g.transform.position = Vector3.Lerp(tempVector,new Vector3(520f,11.73f,0f),i);
			yield return new WaitForSeconds (.005f);
		}

		yield return new WaitForSeconds (5);
		StartCoroutine (cinematicViewOff ());
	}

	IEnumerator cinematicViewOff()
	{
		float scaleY = 3;
		while (scaleY > 1.55f) 
		{
			yield return new WaitForSeconds (.0001f);
			top.transform.localScale = new Vector3 (103, scaleY, 0);
			bottom.transform.localScale = new Vector3 (103, scaleY, 0);
			scaleY -= .01f;
		}

	}

		
}
