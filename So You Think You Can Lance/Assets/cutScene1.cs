using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class cutScene1 : MonoBehaviour {
	public GameObject lance;
	public GameObject hand;
	public GameObject realLance;
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
			col.gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePosition;
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
		yield return new WaitForSeconds (1.5f);

		GameObject sir = GameObject.Find ("SirLance");
		Vector3 temp1 = sir.transform.position;
		for (float i = 0f; i <= 1f; i+= .1f)
		{
			sir.transform.position = Vector3.Lerp(temp1,temp1 + new Vector3(6.3f,0f,0f),i);
			yield return new WaitForSeconds (.0000001f);
			if (i >= .9) 
			{
				Destroy (lance);
				Destroy (bandit.GetComponent<Rigidbody2D> ());
				realLance.GetComponent<SpriteRenderer> ().enabled = true;
				realLance.GetComponent<BoxCollider2D> ().enabled = true;
				realLance.GetComponent<Animator> ().Play ("Pierce");
			}
		}
			
		yield return new WaitForSeconds (1.5f);
		realLance.GetComponent<Animator> ().Play ("Pierce");
		bandit.transform.parent = null;
		bandit.transform.position = GameObject.Find ("Hand").transform.position;
		Vector3 temp2 = bandit.transform.position;
		for (float i = 0f; i < 1f; i+= .01f)
		{
			bandit.transform.position = Vector3.Lerp(temp2,new Vector3(550f,11.73f,0f),i);
			bandit.transform.localRotation = Quaternion.Euler (0,0,-i*2*360);
			yield return new WaitForSeconds (.005f);
		}
		yield return new WaitForSeconds (1);

		GameObject g = GameObject.Find ("Chicken");
		g.transform.localRotation = Quaternion.Euler(0, 180, 0);
		g.GetComponent<Rigidbody2D> ().AddForce (new Vector3 (500, 500, 0));

		yield return new WaitForSeconds (3);
		Destroy (g);
		Destroy (bandit);
		StartCoroutine (cinematicViewOff ());
	}

	IEnumerator cinematicViewOff()
	{
		GameObject g = GameObject.Find ("SirLance");
		g.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		g.GetComponent<Rigidbody2D> ().freezeRotation = true;
		g.GetComponent<Animator> ().enabled = true;
	
		/*
		float scaleY = 3;
		while (scaleY > 1.55f) 
		{
			yield return new WaitForSeconds (.0001f);
			top.transform.localScale = new Vector3 (103, scaleY, 0);
			bottom.transform.localScale = new Vector3 (103, scaleY, 0);
			scaleY -= .01f;
		}
		*/
		yield return new WaitForSeconds (.0001f);
		g.GetComponent<PlatformerCharacter2D> ().inCutscene = false;
	}

		
}
