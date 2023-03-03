using System;
using UnityEngine;

public class TransferImpulse : MonoBehaviour
{

    [SerializeField]
    private float magnitude;

    private Vector3 _lastPos;
    private Vector3 _direction;

    private void Start()
    {
        _lastPos = transform.position;
        _direction = Vector3.zero;
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        
        _direction = (pos - _lastPos).normalized;
        _lastPos = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
        if (otherRigidbody == null)
            return;

        otherRigidbody.AddForce(magnitude * _direction, ForceMode.Impulse);
        
        Destroy(gameObject);
    }

}
