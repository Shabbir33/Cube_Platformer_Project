using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    //integers
    public int maxHealth = 100;
    public int currentHealth;

    //floats
    public float moveSpeed;
    public float jumpHeight;
    public float groundCheckRadius;
    public float projectileCount;

    //References
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public Transform firePoint;
    public GameObject projectile;
    private Text projectileCountText;
    private LevelManager levelManager;


    //Booleans
    private bool grounded;
    private bool canDoubleJump; 


    void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();

        projectileCountText = GameObject.FindGameObjectWithTag("Projectile_Count").GetComponent<Text>();

        levelManager = FindObjectOfType<LevelManager>();
    }

    void FixedUpdate() {
        //Checking Ground 
        grounded = Physics2D.OverlapCircle(groundCheck.position ,groundCheckRadius,whatIsGround);    
    }


    void Update()
    {
        //Movement Left-Right-Jump
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed,rb.velocity.y);
        
        //Jump (Double Jump)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                canDoubleJump = true;
            }
            else
            {
                if(canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight * 0.85f);
                    canDoubleJump = false;                    
                }
            }   
        }

        //Player Flipping
        float playerSizeX = transform.localScale.x;
        if(rb.velocity.x > 0)
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        else if(rb.velocity.x < 0)
            transform.rotation = Quaternion.Euler(0f,-180f,0f);

        //Player Shooting Projectile
        if(Input.GetKeyDown(KeyCode.X) && projectileCount > 0)
        {           
            Instantiate(projectile, firePoint.position, Quaternion.identity);
            projectileCount -= 1;
            
        }
        if(projectileCount <= 0)
        {
            projectileCount = 0;
        }
        projectileCountText.text = "X "+ projectileCount;

        
        if(currentHealth <= 0)
        {
            if(currentHealth < 0)
            {
                currentHealth = 0;
            }
            levelManager.RespawnPlayer();
            Debug.Log("All Hope is Lost.");
        } 
               
    }
}
