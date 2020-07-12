using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update() 
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
    }


























    /*
    //Floats
    public float xFinal; public float yFinal;
    public float moveSpeed;
    private float xInitial; private float yInitial;

    //Booleans
    public bool platformActive;
    public bool atInitialPosistion;

    //References
    private Rigidbody2D rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

        xInitial = transform.position.x;
        yInitial = transform.position.y;

        atInitialPosistion = true;
        
    }

    
    void Update()
    {
        
        if(transform.position.y <= yFinal)
        {
            platformActive = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            //Debug.Log("Got There!");
            //transform.position = new Vector3(xInitial, yFinal, transform.position.z);
        }
        else
        {
            platformActive = true;
        }

        if(atInitialPosistion == false && platformActive == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Player" && platformActive ==true)
        {
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
            atInitialPosistion = false;
        }
        
    }
    */
}
