using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockMo : MonoBehaviour {
	public float speed;
	public int i = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = new Vector3 (this.gameObject.transform.position.x - speed, this.gameObject.transform.position.y, 0f);
		if (i == 0)
		{
			StartCoroutine (spin ());
		}
	}

	IEnumerator spin()
	{
		while (i != 10000) 
		{
			yield return new WaitForSeconds (.001f);
			this.transform.rotation = Quaternion.Euler (0f, 0f, i*2);
			i++;
		}

	}


}
