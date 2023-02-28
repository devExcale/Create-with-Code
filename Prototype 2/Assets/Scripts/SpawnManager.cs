using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 topLeftCorner;
    [SerializeField]
    private Vector2 rangeX;
    [SerializeField]
    private Vector2 rangeZ;

    [SerializeField]
    private Vector2 cooldownRange; //.5 1.5

    [SerializeField]
    private GameObject[] animalPrefabs;

    private Coroutine _spawnAnimalRoutine;

    private void OnEnable()
    {
        StartCoroutine(SpawnAnimalRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnAnimalRoutine());
    }

    private IEnumerator SpawnAnimalRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(cooldownRange.x, cooldownRange.y));

            GameObject animal = animalPrefabs[Random.Range(0, animalPrefabs.Length)];
            Quaternion rotation;
            float x = topLeftCorner.x;
            float y = topLeftCorner.y;
            float z = topLeftCorner.z;

            // Spawn on x axis
            if (Random.value > .5f)
            {   
                x = Random.Range(rangeX.x, x + rangeX.y);
                rotation = Quaternion.Euler(0, 180, 0);
            }
            // Spawn on z axis
            else
            {
                z = Random.Range(rangeZ.x, rangeZ.y);
                rotation = Quaternion.Euler(0, 90, 0);
            }
            
            Vector3 position = new Vector3(x, y, z);
            Instantiate(animal, position, rotation, transform);
        }
        // ReSharper disable once IteratorNeverReturns
    }
    
}
