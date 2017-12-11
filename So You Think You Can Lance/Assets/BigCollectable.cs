using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCollectable : MonoBehaviour {
		public int value;
		private LevelManager lm;
		private Renderer rend;
		private bool isCollected = false;

		// Use this for initialization
		void Start () 
		{
			lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
			rend = GetComponent<Renderer>();
		}

		// Update is called once per frame
		void Update () {

		}
		void OnTriggerEnter2D(Collider2D col)
		{
			if(col.gameObject.tag == "Player" && !isCollected)
			{
				isCollected = true;
				rend.enabled = false;
				for (int i = 0; i < value; i++) 
				{
					lm.CoinCollected ();
				}
				Destroy(this.gameObject);
			}
		}
	}

