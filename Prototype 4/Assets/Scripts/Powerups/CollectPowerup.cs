using ScriptableObjects;
using UnityEngine;

namespace Powerups
{
    public class CollectPowerup : MonoBehaviour
    {

        [SerializeField]
        private CollectableType type;

        [SerializeField]
        private PowerupData powerupData;

        private void OnTriggerEnter(Collider other)
        {
        
            if (!other.CompareTag("Player"))
                return;

            GameObject player = other.gameObject;
            
            // Destroy previous powerup if present
            Powerup powerup = player.GetComponent<Powerup>();
            if (powerup != null) {
                Destroy(powerup);
                powerup = null;
            }

            // Prevent updates while setting up powerup
            player.SetActive(false);

            switch (type)
            {
                case CollectableType.PowerupRepel:
                    powerup = player.AddComponent<PowerupRepel>();
                    break;
            
                case CollectableType.PowerupShockwave:
                    powerup = player.AddComponent<PowerupShockwave>();
                    break;
                
                case CollectableType.PowerupSmash:
                    powerup = player.AddComponent<PowerupSmash>();
                    break;
            }

            if (powerup != null)
                powerup.Data = powerupData;
        
            player.SetActive(true);
            Destroy(gameObject);
        }

        public enum CollectableType
        {
            PowerupRepel,
            PowerupShockwave,
            PowerupSmash
        }

    }
}