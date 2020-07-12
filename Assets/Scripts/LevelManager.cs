using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LevelManager : MonoBehaviour
{
    public Transform checkPointPosition;
    private Player_Controller player;  
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public Image heartsUI;
    public Sprite[] heartSprites;


    public float delayTime;

    void Start()
    {
        player = FindObjectOfType<Player_Controller>();
    }


    void Update()
    {
        if(player.currentHealth < 0)
        {
            player.currentHealth = 0;
        }
        heartsUI.sprite = heartSprites[player.currentHealth];
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, Quaternion.identity);
        player.gameObject.SetActive(false);
        Debug.Log("Respawn Player");
        yield return new WaitForSeconds(delayTime);
        player.gameObject.SetActive(true);
        Instantiate(respawnParticle,checkPointPosition.position,Quaternion.identity);
        //Realign the player to face right
        player.transform.rotation = Quaternion.Euler(0f,0f,0f);
        player.transform.position = checkPointPosition.position;
        if(player.currentHealth <= 0)
        {
            player.currentHealth = player.maxHealth;
        }
    }
}
