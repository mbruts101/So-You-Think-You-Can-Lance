using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Stabbable") 
		{
			Destroy (col.gameObject.GetComponent<BoxCollider2D> ());
			Destroy (this.gameObject.GetComponent<BoxCollider2D> ());
			enemy = col.gameObject;
			StartCoroutine (spin ());
			StartCoroutine (fall ());
		} 

	}

	IEnumerator fall()
	{
		float i = 0;
		while (i <= 5) 
		{
			yield return new WaitForSeconds (.01f);
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - i, 0f);
			i += .01f;
		}
	}

	IEnumerator spin()
	{
		float i = 0;
		while (i <= 5) 
		{
			yield return new WaitForSeconds (.01f);
			enemy.transform.localRotation = Quaternion.Euler (0, 0, -i * 2 * 360);
			i += .01f;
		}
	}
}
