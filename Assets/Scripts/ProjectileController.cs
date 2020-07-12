using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    //Integers
    public int projectileDamage;

    //Floats
    public float speed;

    //References
    public GameObject player;
    public Rigidbody2D rb;
    public GameObject enemyDeathEffect;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player.transform.localEulerAngles.y);

        if(player.transform.localEulerAngles.y == 180f)
        {
            Debug.Log("Called");
            transform.rotation = Quaternion.Euler(0f,-180f,0f);
            speed = -speed;
        }
    }


    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHeathManager>().DamageToGive(projectileDamage);
        }

        /*
        Debug.Log("Detected");
        if(other.gameObject.tag == "Enemy")
        {
            Instantiate(enemyDeathEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            //ScoreManager.AddPoints();
            Debug.Log("Enemy Detected");
        }
        */

        Destroy(gameObject);
    }
}
