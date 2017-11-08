using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {
    public Text coin;
	// Use this for initialization
	void Start () {
        coin.text = PlayerDataKeeper.getCoins().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitShop()
    {
        Application.LoadLevel(0);
    }
}
