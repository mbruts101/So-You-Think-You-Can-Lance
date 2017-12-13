using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class speedChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("Sir Lance").GetComponent<PlatformerCharacter2D> ().maxSpeed = 16;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
