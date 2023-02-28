using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        
        if (other.CompareTag("Animal"))
        {
            Destroy(other.gameObject);
            GetComponentInParent<PlayerController>()?.AddScore(1);
        }
    }
}
