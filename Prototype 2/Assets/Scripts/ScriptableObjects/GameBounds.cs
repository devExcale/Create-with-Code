using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameBounds", menuName = "ScriptableObjects/GameBounds")]
    public class GameBounds : ScriptableObject
    {

        public Vector3 upperBounds = Vector3.positiveInfinity;
        public Vector3 lowerBounds = Vector3.negativeInfinity;

    }
}
