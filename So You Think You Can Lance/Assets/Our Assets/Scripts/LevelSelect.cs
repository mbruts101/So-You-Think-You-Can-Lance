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

public class LevelSelect : MonoBehaviour {
    public Text coin;
	// Use this for initialization
	void Start () {
        coin.text = PlayerPrefs.GetInt("Coins").ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Select1_1()
    {
        SceneManager.LoadScene("cutsceneLevel1");
    }
    public void Select1_2()
    {
        SceneManager.LoadScene("level2");
    }
    public void SelectShop()
    {
        SceneManager.LoadScene("ShopScene");
    }
    public void SelectBoss()
    {
        SceneManager.LoadScene("BossFight");
    }
}
