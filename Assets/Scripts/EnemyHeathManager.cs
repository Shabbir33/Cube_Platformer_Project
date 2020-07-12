using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeathManager : MonoBehaviour
{
    //Integers
    public int enemyHealth;

    //References
    public GameObject deathParticleSystem;

    void Start()
    {

    }

    void Update()
    {
        if(enemyHealth <= 0)
        {
            Instantiate(deathParticleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void DamageToGive(int damage)
    {
        enemyHealth -= damage;
    } 
}
