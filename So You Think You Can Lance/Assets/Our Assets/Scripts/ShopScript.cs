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
    public PlayerDataKeeper data;

    // Use this for initialization
    void Start () {
        
        coin.text = data.getSavedCoins().ToString();
	}
	
	// Update is called once per frame
	void Update () {
        coin.text = data.coins.ToString();
	}

    public void ExitShop()
    {
        Application.LoadLevel(0);
    }
    public void PurpleLance()
    {
        if(data.coins >= 50 && PlayerPrefs.GetInt("BoughtPurple") == 0)
        {
            data.coins -= 50;
            data.saveCoins();
            data.setLance("Purple_Lance");
            boughtPurple = true;
        }
        else if (PlayerPrefs.GetInt("BoughtPurple") == 1)
        {
            data.setLance("Purple_Lance");
        }
    }
    public void BlackLance()
    {
        if (data.coins >= 50 && PlayerPrefs.GetInt("BoughtBlack") == 0)
        {
            data.coins -= 50;
            data.saveCoins();
            data.setLance("Black white Lance");
            boughtBlack = true;
        }
        else if (PlayerPrefs.GetInt("BoughtBlack") == 1)
        {
            data.setLance("Black white Lance");
        }
    }
    public void ChristmasLance()
    {
        if (data.coins >= 100 && PlayerPrefs.GetInt("BoughtChristmas") == 0)
        {
            data.coins -= 100;
            data.setLance("CHRISTMAS LANDCE");
            boughtChristmas = true;
        }
        else if (PlayerPrefs.GetInt("BoughtChristmas") == 1)
        {
            data.setLance("CHRISTMAS LANDCE");
        }
    }
    public void InvertedLance()
    {
        if (data.coins >= 80 && PlayerPrefs.GetInt("BoughtInverted") == 0)
        {
            data.coins -= 80;
            data.setLance("Inverted lance");
            boughtChristmas = true;
        }
        else if (PlayerPrefs.GetInt("BoughtInverted") == 1)
        {
            data.setLance("Inverted lance");
        }
    }

}
