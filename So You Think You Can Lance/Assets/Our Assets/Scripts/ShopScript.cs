//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {
    public Text coin;
    public bool boughtPurple = false;
    public bool boughtInverted = false;
    public bool boughtChristmas = false;
    public bool boughtBlack = false;
    // Use this for initialization
    void Start () {
        
        coin.text = PlayerDataKeeper.getCoins().ToString();
	}
	
	// Update is called once per frame
	void Update () {
        coin.text = PlayerDataKeeper.getCoins().ToString();
	}

    public void ExitShop()
    {
        Application.LoadLevel(0);
    }
    public void PurpleLance()
    {
        if(PlayerDataKeeper.getCoins() > 50 && PlayerPrefs.GetInt("BoughtPurple") == 0)
        {
            PlayerDataKeeper.setCoins(-50);
            PlayerDataKeeper.setLance("Purple_Lance");
            boughtPurple = true;
        }
        else if (PlayerPrefs.GetInt("BoughtPurple") == 1)
        {
            PlayerDataKeeper.setLance("Purple_Lance");
        }
    }
    public void BlackLance()
    {
        if (PlayerDataKeeper.getCoins() > 60 && PlayerPrefs.GetInt("BoughtBlack") == 0)
        {
            PlayerDataKeeper.setCoins(-60);
            PlayerDataKeeper.setLance("Black white Lance");
            boughtBlack = true;
        }
        else if (PlayerPrefs.GetInt("BoughtBlack") == 1)
        {
            PlayerDataKeeper.setLance("Black white Lance");
        }
    }
    public void ChristmasLance()
    {
        if (PlayerDataKeeper.getCoins() > 100 && PlayerPrefs.GetInt("BoughtChristmas") == 0)
        {
            PlayerDataKeeper.setCoins(-100);
            PlayerDataKeeper.setLance("CHRISTMAS LANDCE");
            boughtChristmas = true;
        }
        else if (PlayerPrefs.GetInt("BoughtChristmas") == 1)
        {
            PlayerDataKeeper.setLance("CHRISTMAS LANDCE");
        }
    }
    public void InvertedLance()
    {
        if (PlayerDataKeeper.getCoins() > 80 && PlayerPrefs.GetInt("BoughtInverted") == 0)
        {
            PlayerDataKeeper.setCoins(-80);
            PlayerDataKeeper.setLance("Inverted lance");
            boughtChristmas = true;
        }
        else if (PlayerPrefs.GetInt("BoughtInverted") == 1)
        {
            PlayerDataKeeper.setLance("Inverted lance");
        }
    }

}
