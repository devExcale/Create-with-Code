using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PowerupShockwaveData")]
    public class PowerupShockwaveData : PowerupData
    {

        public GameObject ProjectilePrefab => projectilePrefab;
        
        [SerializeField]
        private GameObject projectilePrefab;

    }
}