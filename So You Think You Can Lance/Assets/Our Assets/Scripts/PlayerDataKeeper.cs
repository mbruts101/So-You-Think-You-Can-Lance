//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerDataKeeper {
    public static int coins;
    public static string Lance;

    public static void setCoins(int newcoins)
    {

        coins = getCoins();
        PlayerPrefs.SetInt("Coins", coins + newcoins);
        PlayerPrefs.Save();
    }
    public static int getCoins()
    {
        if(PlayerPrefs.HasKey("Coins") == false)
        {
            PlayerPrefs.SetInt("Coins", 0);
        }
        return PlayerPrefs.GetInt("Coins");
    }
    public static void setLance(string lance)
    {
        PlayerPrefs.SetString("Lance", lance);
    }
    public static string getLance()
    {
        if (PlayerPrefs.HasKey("Lance") == false) 
        {
            PlayerPrefs.SetString("Lance", "Lance_v1.06");
        }
        return PlayerPrefs.GetString("Lance");
    }
    public static int getPurpleBought()
    {
        if(PlayerPrefs.HasKey("BoughtPurple") == false)
        {
            PlayerPrefs.SetInt("BoughtPurple", 0);
        }
        return PlayerPrefs.GetInt("BoughtPurple");
    }
    public static int getInvertedBought()
    {
        if (PlayerPrefs.HasKey("BoughtInverted") == false)
        {
            PlayerPrefs.SetInt("BoughtInverted", 0);
        }
        return PlayerPrefs.GetInt("BoughtInverted");
    }
    public static int getBlackBought()
    {
        if (PlayerPrefs.HasKey("BoughtBlack") == false)
        {
            PlayerPrefs.SetInt("BoughtBlack", 0);
        }
        return PlayerPrefs.GetInt("BoughtBlack");
    }
    public static int getChristmasBought()
    {
        if (PlayerPrefs.HasKey("BoughtChristmas") == false)
        {
            PlayerPrefs.SetInt("BoughtChristmas", 0);
        }
        return PlayerPrefs.GetInt("BoughtChristmas");
    }
    public static void setPurpleBought(int status)
    {
        PlayerPrefs.SetInt("BoughtPurple", status);
        PlayerPrefs.Save();
    }
    public static void setInvertedBought(int status)
    {
        PlayerPrefs.SetInt("BoughtInverted", status);
        PlayerPrefs.Save();
    }
    public static void setBlackBought(int status)
    {
        PlayerPrefs.SetInt("BoughtBlack", status);
        PlayerPrefs.Save();
    }
    public static void setChristmasBought(int status)
    {
        PlayerPrefs.SetInt("BoughtChristmas", status);
        PlayerPrefs.Save();
    }
}
