//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    
    public int coinsTotal;
    public Text coinscollectedText;
    public Text coinsTotalText;
    public PlayerDataKeeper data;

	// Use this for initialization
	void Start () {
        CountTotalCoinsAvailable();
        data.coins = data.getSavedCoins();
        coinscollectedText.text = data.coins.ToString();
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
        data.coins += 1;
        coinscollectedText.text = data.coins.ToString();
    }
}
