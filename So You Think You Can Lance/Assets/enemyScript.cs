using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {
    public float speed;
    public bool active;

	// Use this for initialization
	void Start () {
        active = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            this.transform.position = new Vector3(this.transform.position.x - speed, this.transform.position.y);
        }
    }

        void OnTriggerEnter2D(Collider2D c)
        {
            active = true;
        }
	}

