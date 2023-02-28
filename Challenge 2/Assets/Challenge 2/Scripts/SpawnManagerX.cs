using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    [SerializeField]
    private float startDelay = 1.0f;
    [SerializeField]
    private float spawnInterval = 4.0f;
    [SerializeField]
    private float spawnRandomOffset = 1f;

    private void OnEnable()
    {
        StartCoroutine(SpawnRandomBallRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnRandomBallRoutine());
    }

    // Spawn random ball at random x position at top of play area
    private IEnumerator SpawnRandomBallRoutine()
    {
        while (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(startDelay);
        
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            int i = Random.Range(0, ballPrefabs.Length);
            
            Instantiate(ballPrefabs[i], spawnPos, ballPrefabs[i].transform.rotation);

            startDelay = Random.Range(spawnInterval - spawnRandomOffset, spawnInterval + spawnRandomOffset);
        }
        // ReSharper disable once IteratorNeverReturns
    }

}
