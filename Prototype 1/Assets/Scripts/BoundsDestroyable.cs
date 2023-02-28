using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsDestroyable : MonoBehaviour
{

    [SerializeField]
    private Vector3 upperBounds;

    [SerializeField]
    private Vector3 lowerBounds;

    // Update is called once per frame
    void Update()
    {

        if (IsOutOfBounds())
        {
            Destroy(gameObject);
        }
        
    }

    private bool IsOutOfBounds()
    {
        Vector3 pos = transform.position;
        return pos.x < lowerBounds.x || pos.x > upperBounds.x ||
               pos.y < lowerBounds.y || pos.y > upperBounds.y ||
               pos.z < lowerBounds.z || pos.z > upperBounds.z;
    }
    
}
