//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class PlayerDataKeeper : MonoBehaviour{
    public int coins;
    public string Lance;
    public int startingCoins;

    void Start()
    {
        startingCoins = PlayerPrefs.GetInt("Coins");
    }

    public void resetCoins()
    {
        Debug.Log(startingCoins);
        PlayerPrefs.SetInt("Coins", startingCoins);
        PlayerPrefs.Save();
    }

    public void saveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }
    public int getSavedCoins()
    {
        if(PlayerPrefs.HasKey("Coins") == false)
        {
            PlayerPrefs.SetInt("Coins", 0);
        }
        return PlayerPrefs.GetInt("Coins");
    }


    public void setLance(string lance)
    {
        PlayerPrefs.SetString("Lance", lance);
        PlayerPrefs.Save();
    }
    public string getLance()
    {
        if (PlayerPrefs.HasKey("Lance") == false) 
        {
            PlayerPrefs.SetString("Lance", "Lance_v1.06");
        }
        return PlayerPrefs.GetString("Lance");
    }
    public int getPurpleBought()
    {
        if(PlayerPrefs.HasKey("BoughtPurple") == false)
        {
            PlayerPrefs.SetInt("BoughtPurple", 0);
        }
        return PlayerPrefs.GetInt("BoughtPurple");
    }
    public int getInvertedBought()
    {
        if (PlayerPrefs.HasKey("BoughtInverted") == false)
        {
            PlayerPrefs.SetInt("BoughtInverted", 0);
        }
        return PlayerPrefs.GetInt("BoughtInverted");
    }
    public int getBlackBought()
    {
        if (PlayerPrefs.HasKey("BoughtBlack") == false)
        {
            PlayerPrefs.SetInt("BoughtBlack", 0);
        }
        return PlayerPrefs.GetInt("BoughtBlack");
    }
    public int getChristmasBought()
    {
        if (PlayerPrefs.HasKey("BoughtChristmas") == false)
        {
            PlayerPrefs.SetInt("BoughtChristmas", 0);
        }
        return PlayerPrefs.GetInt("BoughtChristmas");
    }
    public void setPurpleBought(int status)
    {
        PlayerPrefs.SetInt("BoughtPurple", status);
        PlayerPrefs.Save();
    }
    public void setInvertedBought(int status)
    {
        PlayerPrefs.SetInt("BoughtInverted", status);
        PlayerPrefs.Save();
    }
    public void setBlackBought(int status)
    {
        PlayerPrefs.SetInt("BoughtBlack", status);
        PlayerPrefs.Save();
    }
    public void setChristmasBought(int status)
    {
        PlayerPrefs.SetInt("BoughtChristmas", status);
        PlayerPrefs.Save();
    }
}
