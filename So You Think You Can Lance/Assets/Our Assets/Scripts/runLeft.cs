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
		for (int i = 0; i < 100; i++) 
		{
			yield return new WaitForSeconds (.1f);
            if (rb != null)
            {
                rb.AddForce(50.0f * Vector2.left);
            }
		}
	}


	void FixedUpdate()
	{
		
	}
}
