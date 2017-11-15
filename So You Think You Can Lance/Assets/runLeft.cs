using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runLeft : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector2 (this.transform.position.x - speed, this.transform.position.y);
	}
}
