using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Select1_1()
    {
        Application.LoadLevel("testScene");
    }
    public void Select1_2()
    {
        Application.LoadLevel("level2");
    }
}
