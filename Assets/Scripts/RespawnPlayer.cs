using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public LevelManager levelManager;
    private Player_Controller player;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player" && player.currentHealth > 0)
        {
            levelManager.RespawnPlayer();
        }   
    }
}
