using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehaviour : MonoBehaviour {
    public Transform[] Positions;
    public float speed;
    public Transform FireballLaunchPosition;
    public GameObject fireball;
    public Transform EggLaunchPosition;
    public GameObject egg;
    public int health = 3;
    public bool dead = false;
    public Animator anim;
    public SpriteRenderer spr;
    public int fireSpeed = 15;
    public AudioSource[] audios;
    public AudioSource slow;
    public AudioSource medium;
    public AudioSource fast;
    private bool invincible;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        audios = GetComponents<AudioSource>();
        slow = audios[0];
        medium = audios[1];
        fast = audios[2];
        StartCoroutine("BossPattern");
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0 && !dead)
        {
            dead = true;
            StopCoroutine("BossPattern");
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }
	}

    IEnumerator BossPattern()
    {
        while (health > 0)
        {
            //First Attack
            while (transform.position.x != Positions[0].position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Positions[0].position.x, transform.position.y), speed);
                yield return null;
            }
            yield return new WaitForSeconds(1);
            for (int i = 0; i < 6; i++)
            {
                anim.SetBool("Attacking", true);
                yield return new WaitForSeconds(0.5f);
                GameObject fireballProjectile = (GameObject)Instantiate(fireball, FireballLaunchPosition.position, Quaternion.identity);
                fireballProjectile.GetComponent<Rigidbody2D>().velocity = Vector2.left * fireSpeed;
                yield return new WaitForSeconds(1);
                anim.SetBool("Attacking", false);
                yield return new WaitForSeconds(1);

            }
            anim.SetBool("Attacking", false);
            //SecondAttack
            GetComponent<Rigidbody2D>().isKinematic = true;
            while (transform.position != Positions[1].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Positions[1].position.x, Positions[1].position.y), speed);
                yield return null;
            }
            yield return new WaitForSeconds(1);
            while (transform.position != Positions[2].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Positions[2].position.x, Positions[2].position.y), speed);
                yield return null;
            }
            for (int i = 0; i < 1; i++)
            {
                GameObject eggProjectile = (GameObject)Instantiate(egg, EggLaunchPosition.position, Quaternion.identity);
                eggProjectile.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;
                yield return new WaitForSeconds(2);
            }
            //Time For the Player to Attack
            while (transform.position != Positions[3].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Positions[3].position.x, Positions[3].position.y), speed);
                yield return null;
            }
            yield return new WaitForSeconds(1);
            while (transform.position != Positions[4].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Positions[4].position.x, Positions[4].position.y), speed);
                yield return null;
            }
            yield return null;
        }
        
    }
  
    void OnTriggerEnter2D(Collider2D col)
    {
		Debug.Log (col.gameObject.name);
        if(col.gameObject.tag == "Stabbable")
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
           
            health = health - 1;
               
            if(health == 2)
            {
                slow.Stop();
                medium.Play();
                speed = speed * 2;
                fireSpeed = 25;
            }
            if (health == 1)
            {
                medium.Stop();
                fast.Play();
                speed = speed * 2;
                fireSpeed = 35;
            }
            
        }
    }
}
