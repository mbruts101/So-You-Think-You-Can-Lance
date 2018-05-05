//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour {

    public PlayerDataKeeper data;

    void Start()
    {
        data = GameObject.Find("LevelManager").GetComponent<PlayerDataKeeper>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		if(col.gameObject.tag == "Player") 
		{
            data.resetCoins();
			Debug.Log (col.gameObject.name);
			Destroy (col.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

}
