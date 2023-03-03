using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    [SerializeField]
    private Vector3 upperBounds = Vector3.positiveInfinity;
    [SerializeField]
    private Vector3 lowerBounds = Vector3.negativeInfinity;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        // For each axis check if out of range
        bool outX = pos.x < lowerBounds.x || pos.x > upperBounds.x;
        bool outY = pos.y < lowerBounds.y || pos.y > upperBounds.y;
        bool outZ = pos.z < lowerBounds.z || pos.z > upperBounds.z;

        if (outX || outY || outZ)
            Destroy(gameObject);
    }
}
