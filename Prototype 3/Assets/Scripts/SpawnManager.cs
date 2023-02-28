using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Vector3 position;

    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private float spawnDelay;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(Spawn), spawnDelay, 1f/spawnRate);
    }

    private void Spawn()
    {
        if (_playerController.GameOver)
            return;
        
        Instantiate(prefab, position, prefab.transform.rotation, gameObject.transform);
    }
    
}
