//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    private LevelManager lm;
    private Renderer rend;
    private bool isCollected = false;
    // Use this for initialization
    void Start () {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && !isCollected)
        {
            isCollected = true;
            rend.enabled = false;
            lm.CoinCollected();
            Destroy(this.gameObject);
        }
    }
}
