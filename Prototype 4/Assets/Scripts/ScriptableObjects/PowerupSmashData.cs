using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PowerupSmashData")]
    public class PowerupSmashData : PowerupData
    {

        public float JumpImpulse => jumpImpulse;

        [SerializeField]
        private float jumpImpulse;

        public float Intensity => intensity;

        [SerializeField]
        private float intensity;

        public float Radius => radius;

        [SerializeField]
        private float radius;

    }
}