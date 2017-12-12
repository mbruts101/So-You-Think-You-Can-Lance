using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pee : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "Player") 
		{
			
			col.gameObject.GetComponent<runLeft> ().enabled = false;
			GameObject.Find ("LanceLeft").GetComponent<Animator> ().enabled = false;
			GameObject.Find ("PropMan").GetComponent<Projectile> ().enabled = true;
			StartCoroutine (piss ());

		}
	}

	IEnumerator piss()
	{
		yield return new WaitForSeconds (1f);
		GameObject.Find ("Piss").GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (4f);
		GameObject.Find ("Piss").GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (.5f);

		GameObject g = GameObject.Find ("PropMan");

		g.transform.rotation = Quaternion.Euler (0f, 0f, 0f);
		g.GetComponent<Projectile> ().enabled = false;
		GameObject.Find ("LanceLeft").GetComponent<Animator> ().enabled = true;



		g.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;


		GameObject.Find ("Horse").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("PropManLance").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("tent").GetComponent<SpriteRenderer> ().enabled = false;
		Vector3 temp = g.gameObject.transform.position;
		for(float i = 0; i <= 50; i += .1f)
		{
			yield return new WaitForSeconds (.001f);
			g.transform.position = new Vector3 (temp.x + i, temp.y, 0f);
		}
		GameObject.Find("LanceLeft").GetComponent<Animator> ().enabled = false;
		yield return new WaitForSeconds (.5f);
	}
}
