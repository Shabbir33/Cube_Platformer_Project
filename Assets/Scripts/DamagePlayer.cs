using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    //int
    public int damageCount;

    //References
    private LevelManager levelManager;
    private Player_Controller player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
    }


    void Update()
    {
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.currentHealth -= damageCount; 
        }
    }
}
