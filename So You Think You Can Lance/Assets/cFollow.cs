using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cFollow : MonoBehaviour {
	public GameObject lance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = lance.transform.position;
	}
}
