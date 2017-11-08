//Michael Brutsch
//1933153
//bruts101@mail.chapman.edu
//Level Design 2
//So You Think You Can Lance
//Changed the class to fit my needs. Added touch input and changed jump functions. 
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnitySampleAssets._2D
{

    public class PlatformerCharacter2D : MonoBehaviour
    {
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
			if (rb.velocity.magnitude == 0) {
				frameCount++;
				if (Time.timeSinceLevelLoad > 0 && reloadLevel && frameCount > 1) {
					Debug.Log ("loading");
					SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
					reloadLevel = false;   
					frameCount = 0;
				}
                
			} 
			else 
			{
				frameCount = 0;
			}
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


        public void Move(float move, bool crouch, bool jump)
        {


            // If crouching, check to see if the character can stand up
            if (!crouch && anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
                    crouch = true;
            }

            // Set whether or not the character is crouching in the animator
            anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (grounded || airControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move * crouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !facingRight)
                    // ... flip the player.
                    Flip();
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && facingRight)
                    // ... flip the player.
                    Flip();
            }


        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}