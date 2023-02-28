using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private float DeltaSpeed => speed * Time.deltaTime;
    
    void Update()
    {
        transform.Rotate(DeltaSpeed * Vector3.forward);
    }
}
