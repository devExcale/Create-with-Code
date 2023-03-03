using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private Rigidbody _rigidbody;
    private GameObject _focalPoint;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(forwardInput * speed * _focalPoint.transform.forward);
    }

}
