using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickup : MonoBehaviour
{
    public int pointsToAdd;
    public AudioSource pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            ScoreManager.AddPoints(pointsToAdd);

            pickupSound.Play();

            Destroy(gameObject);
        }
    }
}
