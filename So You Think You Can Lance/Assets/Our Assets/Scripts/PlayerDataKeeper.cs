using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerDataKeeper {
    public static int coins;
	
    public static void setCoins(int newcoins)
    {
        coins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetFloat("Coins", coins + newcoins);
        PlayerPrefs.Save();
    }
    public static float getCoins()
    {
        return PlayerPrefs.GetInt("Coins");
    }
}
