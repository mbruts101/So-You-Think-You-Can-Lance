using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        StartCoroutine("BossPattern");
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0 && !dead)
        {
            dead = true;
            StopCoroutine("BossPattern");
            //Animate death here
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
                fireballProjectile.GetComponent<Rigidbody2D>().velocity = Vector2.left * 15;
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
            for (int i = 0; i < 6; i++)
            {
                GameObject eggProjectile = (GameObject)Instantiate(egg, EggLaunchPosition.position, Quaternion.identity);
                eggProjectile.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;
                yield return new WaitForSeconds(1);
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
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Lance")
        {
            health = health - 1;
            speed = speed * 2;
        }
    }
}
