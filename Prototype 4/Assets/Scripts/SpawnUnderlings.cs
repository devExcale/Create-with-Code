using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnUnderlings : MonoBehaviour
{

    [SerializeField]
    private GameObject underling;
    
    [SerializeField]
    private float delay = 2f;
    [SerializeField]
    private float radius;

    private Transform _parent;

    private void OnEnable()
    {
        _parent = transform.parent;
        InvokeRepeating(nameof(SpawnUnderling), delay, delay);
    }

    private void SpawnUnderling()
    {
        Vector3 bossPos = transform.position;
        float angle = Random.Range(0f, 2f * (float)Math.PI);

        float x = bossPos.x + radius * Mathf.Cos(angle);
        float z = bossPos.z + radius * Mathf.Sin(angle);

        Instantiate(underling, new Vector3(x, bossPos.y, z), Quaternion.identity, _parent);
    }
    
}