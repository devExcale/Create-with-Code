using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private float DeltaSpeed => speed * Time.deltaTime;

    private void Update()
    {
        transform.Translate(DeltaSpeed * Vector3.forward);
    }
}
