using System;
using UnityEngine;

namespace Powerups
{
    public class PowerupRepel : Powerup
    {

        [SerializeField]
        private float powerupStrength = 20f;

        private void OnCollisionEnter(Collision other)
        {
            // React to enemies only
            GameObject otherObject = other.gameObject;
            if (!otherObject.CompareTag("Enemy"))
                return;
            
            // Push enemy away
            Rigidbody enemyRigidbody = otherObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.transform.position - transform.position;
            enemyRigidbody.AddForce(powerupStrength * awayFromPlayer, ForceMode.Impulse);
        }
        
    }
}