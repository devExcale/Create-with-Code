using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    
    [SerializeField]
    private GameObject plane;
    
    [SerializeField]
    private Vector3 offset;

    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
    
}
