using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runLeft : MonoBehaviour {
	public float speed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		StartCoroutine (force ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator force()
	{
		while(this.GetComponent<Projectile>().enabled == false)
		{
			yield return new WaitForSeconds (.01f);
			this.transform.position = new Vector3 (this.transform.position.x - speed, this.transform.position.y, 0f);
		}
	}


	void FixedUpdate()
	{
		
	}
}
