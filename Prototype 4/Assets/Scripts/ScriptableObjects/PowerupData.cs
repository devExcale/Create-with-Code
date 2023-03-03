using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PowerupData")]
    public class PowerupData : ScriptableObject
    {

        public float Duration => duration;
    
        public GameObject IndicatorPrefab => indicatorPrefab;

        [SerializeField]
        private float duration = 5f;

        [SerializeField]
        private GameObject indicatorPrefab;
    
    }
}
