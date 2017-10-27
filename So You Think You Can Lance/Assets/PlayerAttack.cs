//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySampleAssets._2D;

public class PlayerAttack : MonoBehaviour
{
    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startSwipePos;
    private bool attacking = false;
    private float attackTimer = 0f;
    private float attackCoolDown = 0.5f;
    public Collider2D attackTrigger;
    public Collider2D upAttackTrigger;
    private Animator anim;
	private SpriteRenderer attackSR;
	private SpriteRenderer lanceSR;
    public GameObject Player;
	public GameObject lance;


    // Use this for initialization
    void Awake()
    {

        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
        
        upAttackTrigger.enabled = false;
        Player = GameObject.FindGameObjectWithTag("Player");

    }
    void Start()
    {
		attackSR = attackTrigger.GetComponent<SpriteRenderer> ();
		lanceSR = lance.GetComponent<SpriteRenderer> ();
    }

    public void attack()
    {
        attacking = true;
        attackTimer = 0;
        attackTrigger.gameObject.active = true;
        attackTrigger.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && !attacking)
        {
            attacking = true;
            attackTimer = 0;
            attackTrigger.gameObject.active = true;
            attackTrigger.enabled = true;
			//sprites
			lanceSR.enabled = false;
			attackSR.enabled = true;

        }
        if (Input.GetKeyDown(KeyCode.W) && !attacking)
        {
            attacking = true;
            attackTimer = 0;

            upAttackTrigger.enabled = true;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                startSwipePos = touch.position;

            }
            if (touch.phase == TouchPhase.Ended)
            {
                float swipeDistVertical = Mathf.Abs(touch.position.y - startSwipePos.y);
                float swipeDistHorizontal = Mathf.Abs(touch.position.x - startSwipePos.x);

                if (swipeDistVertical > minSwipeDistY)
                {
                    float swipeValue = Mathf.Sign(touch.position.y - startSwipePos.y);
                    if (swipeValue > 0)
                    {
                        attacking = true;
                        attackTimer = 0;
                        upAttackTrigger.enabled = true;
                    }
                    else if (swipeValue < 0)
                    {
                        //future down swipe attack
                    }

                }
                if (swipeDistHorizontal > minSwipeDistX)
                {
                    float swipeValue = Mathf.Sign(touch.position.x - startSwipePos.x);
                    if (swipeValue > 0)
                    {
                        attacking = true;
                        attackTimer = 0;
                        attackTrigger.gameObject.active = false;
                        attackTrigger.enabled = true;

                    }
                    else if (swipeValue < 0)
                    {
                        //future back swipe move?
                    }
                }
            }

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

				//sprites
				attackSR.enabled = false;
				lanceSR.enabled = true;
            }
        }
    }
}
