using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
    private ParticleSystem thisParticleSystem;

    void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        if(thisParticleSystem.isPlaying)
        {
        }
        else
        {
            Destroy(gameObject);            
        }
    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject);   
    }
}
