using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3 offset = Vector3.zero;

    [SerializeField]
    private bool enableX;

    [SerializeField]
    private bool enableY;

    [SerializeField]
    private bool enableZ;

    private Quaternion _initialRotation;

    private void Start()
    {
        _initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.position = player.transform.position + offset;
    }

    private void Rotate()
    {
        transform.rotation = _initialRotation;
        if (enableX)
            transform.RotateAround(player.transform.position, Vector3.right, player.transform.rotation.eulerAngles.x);
        if (enableY)
            transform.RotateAround(player.transform.position, Vector3.up, player.transform.rotation.eulerAngles.y);
        if (enableZ)
            transform.RotateAround(player.transform.position, Vector3.forward, player.transform.rotation.eulerAngles.z);
    }
}