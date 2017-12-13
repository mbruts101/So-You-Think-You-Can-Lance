using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class waterDeath : MonoBehaviour {
	
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GameObject.Find ("SirLance").GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			StartCoroutine (sink ());
		}
	}

	IEnumerator sink()
	{
		yield return new WaitForSeconds (.2f);
		rb.constraints = RigidbodyConstraints2D.FreezePosition;

		GameObject g = GameObject.Find ("SirLance");
		for (int i = 0; i <= 41; i++) 
		{
			yield return new WaitForSeconds (.00001f);
			g.transform.rotation = Quaternion.Euler (0, 0, i);
			if (i > 40)
			{
				rb.constraints = RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;
			}
		}
		yield return new WaitForSeconds (.4f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
