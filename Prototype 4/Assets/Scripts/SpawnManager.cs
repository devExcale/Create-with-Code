using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Vector2 rangeX = Vector2.zero;
    [SerializeField]
    private Vector2 rangeZ = Vector2.zero;
    
    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        float x = Random.Range(rangeX.x, rangeX.y);
        float z = Random.Range(rangeZ.x, rangeZ.y);
        Vector3 spawnPos = new Vector3(x, 0f, z);
        
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity, transform);
    }
    
}
