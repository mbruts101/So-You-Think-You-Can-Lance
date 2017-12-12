using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceRederer : MonoBehaviour {
    public SpriteRenderer spr;
	// Use this for initialization
	void Start () {
        spr = this.GetComponent<SpriteRenderer>();
        string lanceString = PlayerDataKeeper.getLance();
        Debug.Log(lanceString);
        spr.sprite = Resources.Load<Sprite>("Lances/"+ lanceString);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
