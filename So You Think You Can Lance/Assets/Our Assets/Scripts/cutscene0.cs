using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class cutscene0 : MonoBehaviour {
	public Sprite idle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Horse")
		{
			col.gameObject.GetComponent<runLeft> ().enabled = false;
			col.gameObject.GetComponent<Animator> ().enabled = false;
			col.gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePosition;
			col.gameObject.GetComponent<Projectile> ().enabled = true;

			StartCoroutine (jump ());
		}
	}


	IEnumerator jump()
	{
		yield return new WaitForSeconds (1f);
		GameObject g = GameObject.Find ("PropMan");
		g.GetComponent<BoxCollider2D> ().enabled = true;

		g.AddComponent<Rigidbody2D> ();
		Rigidbody2D rb = g.GetComponent<Rigidbody2D> ();
		Destroy(GameObject.Find ("Horse").GetComponent<BoxCollider2D> ());
		g.gameObject.transform.position = new Vector3 (g.gameObject.transform.position.x - 2f, g.gameObject.transform.position.y, 0f);
		g.gameObject.transform.localRotation = Quaternion.Euler (0f, 180f, 0);
		GameObject.Find ("Main Camera").GetComponent<Camera2DFollow> ().target = g.transform;
		rb.AddForce(new Vector3(-300f,300f,0f));


		GameObject propLance = GameObject.Find ("PropManLance");
		Vector3 temp = propLance.transform.position;
		propLance.transform.parent = null;
		for(float i = 0; i <= 1; i+=.01f)
		{
			yield return new WaitForSeconds (.01f);

			propLance.gameObject.transform.position = Vector3.Lerp (temp, GameObject.Find ("LanceDropoff").transform.position, i);
			propLance.gameObject.transform.localRotation = Quaternion.Euler (0f, 0f, 60 - i *3* 150);
		}
			
		yield return new WaitForSeconds (2.5f);





		g.AddComponent<runLeft> ();
		g.GetComponent<runLeft> ().speed = .1f;
		g.AddComponent<Projectile> ();
		g.GetComponent<Projectile>().enabled = false;
		Destroy(GameObject.Find("LanceRight"));
		GameObject.Find("LanceLeft").GetComponent<Animator>().enabled = true;
		GameObject.Find ("LanceLeft").GetComponent<SpriteRenderer> ().sortingLayerName = "Background";
		GameObject.Find ("PeeHere").GetComponent<BoxCollider2D> ().enabled = true;
	}
			
}
