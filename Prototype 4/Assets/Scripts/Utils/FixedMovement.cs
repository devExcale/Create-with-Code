using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FixedMovement : MonoBehaviour
{

    [SerializeField]
    private Vector3 speed;

    [SerializeField]
    private Vector3 rotationSpeed;

    void Update()
    {
        transform.Translate(Time.deltaTime * speed);
        transform.Rotate(Time.deltaTime * rotationSpeed);
    }
}
