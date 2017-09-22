//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;
    private float attackTimer = 0f;
    private float attackCoolDown = 2f;
    public Collider2D attackTrigger;
    public Collider2D upAttackTrigger;
    private Animator anim;
	// Use this for initialization
	void Awake () {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
        upAttackTrigger.enabled = false;
	}
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.D) && !attacking){
            attacking = true;
            attackTimer = 0;

            attackTrigger.enabled = true;
           
        }
        if(Input.GetKeyDown(KeyCode.W) && !attacking)
        {
            attacking = true;
            attackTimer = 0;

            upAttackTrigger.enabled = true;
        }
        if (attacking)
        {
            
            if (attackTimer < attackCoolDown)
            {
                attackTimer += Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
                upAttackTrigger.enabled = false;
            }
        }
    }
}
