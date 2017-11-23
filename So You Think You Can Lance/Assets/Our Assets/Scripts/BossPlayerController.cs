using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossPlayerController : MonoBehaviour {

    private bool facingRight = true; // For determining which way the player is currently facing.

    [SerializeField]
    private float maxSpeed = 10f; // The fastest the player can travel in the x axis.
    [SerializeField]
    private float jumpForce = 10f; // Amount of force added when the player jumps.

    [Range(0, 1)]
    [SerializeField]
    private float crouchSpeed = .36f;
    // Amount of maxSpeed applied to crouching movement. 1 = 100%

    [SerializeField]
    private bool airControl = false; // Whether or not a player can steer while jumping;
    [SerializeField]
    private LayerMask whatIsGround; // A mask determining what is ground to the character

    private Transform groundCheck; // A position marking where to check if the player is grounded.
    private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public bool grounded = false; // Whether or not the player is grounded.
    private Transform ceilingCheck; // A position marking where to check for ceilings
    private float ceilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator anim; // Reference to the player's animator component.
    protected Vector2 jumpSpeed;
    public float jumpTakeOffSpeed = 7;
    public bool jumping;
    public float jumpTimer;
    public Vector2 maxJumpSpeed;
    private Vector2 velocity;
    float timer;
    Rigidbody2D rb;
    public AudioSource dirtRun;
    public AudioSource dirtJump;
    public bool reloadLevel = true;
    private int frameCount;
    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startSwipePos;
    private bool attacking = false;
    private float attackTimer = 0f;
    private float attackCoolDown = 0.5f;
    public Collider2D attackTrigger;
    public Collider2D upAttackTrigger;

    private void Awake()
    {

        // Setting up references.
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        anim = GetComponent<Animator>();
        maxJumpSpeed.y = 7;
        rb = GetComponent<Rigidbody2D>();
        AudioSource[] audios = GetComponents<AudioSource>();
        dirtRun = audios[0];
        dirtJump = audios[1];


    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            grounded = false;
            jumping = true;

            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0f, jumpForce));
            dirtRun.Stop();
            dirtJump.Play();


        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, -jumpForce * 0.25f));
            dirtJump.Stop();
            StartCoroutine(delayedRunSound());

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began && grounded)
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
                        attackTrigger.gameObject.active = true;
                        attackTrigger.enabled = true;

                        GameObject.Find("Lance").GetComponent<Animator>().Play("Pierce");

                    }
                    else if (swipeValue < 0)
                    {
                        //future back swipe move?
                    }
                }
                else
                {
                    grounded = false;
                    jumping = true;
                    anim.SetBool("Ground", false);
                    rb.AddForce(new Vector2(0f, jumpForce));
                    dirtRun.Stop();
                    dirtJump.Play();
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.D) && !attacking)
        {
            attacking = true;
            attackTimer = 0;
            attackTrigger.gameObject.active = true;
            attackTrigger.enabled = true;

            GameObject.Find("Lance").GetComponent<Animator>().Play("Pierce");

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
    IEnumerator delayedRunSound()
    {
        yield return new WaitForSeconds(0.5f);
        dirtRun.Play();
    }
    private void FixedUpdate()
    {
        velocity += Physics2D.gravity * Time.deltaTime;
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        // Set the vertical animation
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
    }
}
