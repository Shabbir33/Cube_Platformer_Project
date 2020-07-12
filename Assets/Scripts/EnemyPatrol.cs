using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    //Floats
    public float moveSpeed;
    public float direction;

    //Bools
    [SerializeField] bool isFacingRight = true;

    //References
    public LayerMask groundLayers;
    private Rigidbody2D rb;
    public Transform groundCheck;
    RaycastHit2D hitDown;
    RaycastHit2D hitFront;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hitDown = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayers);  
        hitFront = Physics2D.Raycast(groundCheck.position, new Vector2(direction, 0f), 0.2f, groundLayers);         
    }

    void FixedUpdate() 
    {
        Debug.Log(hitFront.collider);
        if(hitDown.collider != false && hitFront.collider == false)
        {
            if(isFacingRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                direction = 1f;
            }else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                direction = -1f;
            }
        }else
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }    
    }
}
