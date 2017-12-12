using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateEnableCollider : MonoBehaviour {
    public CircleCollider2D circle;
	// Use this for initialization
	void Start () {
        circle = GetComponent<CircleCollider2D>();
        StartCoroutine("DelayedEnable");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator DelayedEnable()
    {
        yield return new WaitForSeconds(1);
        circle.enabled = true;
    }
}
