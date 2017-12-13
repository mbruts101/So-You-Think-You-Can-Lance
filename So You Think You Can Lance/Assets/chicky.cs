using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicky : MonoBehaviour {
	public bool flipped = false;
	// Use this for initialization
	void Start () {
		StartCoroutine (flip ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator flip()
	{
		while(true)
		{
			yield return new WaitForSeconds(Random.Range(.5f,2f));
			flipped = !flipped;
			this.gameObject.GetComponent<SpriteRenderer>().flipX = flipped;
		}
	}
}
