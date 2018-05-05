//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceRederer : MonoBehaviour {
    public SpriteRenderer spr;
    public PlayerDataKeeper data;

	// Use this for initialization
	void Start () {
        spr = this.GetComponent<SpriteRenderer>();
        string lanceString = data.getLance();
        Debug.Log(lanceString);
        spr.sprite = Resources.Load<Sprite>("Lances/"+ lanceString);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
