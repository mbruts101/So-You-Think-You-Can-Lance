//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public int coinsTotal;
    public int coinsCollected = 0;
	// Use this for initialization
	void Start () {
        CountTotalCoinsAvailable();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CountTotalCoinsAvailable()
    {
        coinsTotal = GameObject.FindGameObjectsWithTag("Collectable").Length;

    }
    public void CoinCollected()
    {
        coinsCollected += 1;
    }
}
