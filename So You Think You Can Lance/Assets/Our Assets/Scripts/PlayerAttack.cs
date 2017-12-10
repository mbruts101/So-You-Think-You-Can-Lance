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
    public GameObject Player;


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

    }

	IEnumerator chuck()
	{
		float i = 0f;
		GameObject g = GameObject.Find("LanceEmpty");
		Transform child = g.transform.GetChild (0);
		Vector3 temp = g.transform.position;


		child.parent = null;
		while(i<=1)
		{
			yield return new WaitForSeconds(.01f);
            if (child != null)
            {
                child.position = Vector3.Lerp(temp, temp + new Vector3(50f, 0f, 0f), i);
                child.localRotation = Quaternion.Euler(0, 0, -i * 2 * 360);
                i += .03f;
                if (i > .1)
                {
					child.gameObject.GetComponent<Obstacle> ().enabled = false;
					child.gameObject.AddComponent<BoxCollider2D>();

                }
            }
		}

		Destroy (child.gameObject);

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
			if (GameObject.Find ("LanceEmpty").transform.childCount != 0) 
			{
				StartCoroutine(chuck());
			}
            attacking = true;
            attackTimer = 0;
            attackTrigger.gameObject.active = true;
            attackTrigger.enabled = true;

			GameObject.Find ("Lance").GetComponent<Animator> ().Play ("Pierce");

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
            }
        }
    }
}
