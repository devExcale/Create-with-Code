using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private Vector3[] spawnPositions;

    [SerializeField]
    private Vector3 spawnOffset;

    [SerializeField]
    private Vector3 spawnRotation;

    [SerializeField]
    private bool isRandomSpawnPosition;

    [SerializeField]
    private float cooldown;

    private WaitForSeconds _waitCooldown;

    private void OnEnable()
    {
        _waitCooldown = new WaitForSeconds(cooldown);
        StartCoroutine(SpawnObstacleRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnObstacleRoutine());
    }

    private IEnumerator SpawnObstacleRoutine()
    {
        int i = 0;
        while (true)
        {
            int index = isRandomSpawnPosition ? Random.Range(0, spawnPositions.Length) : i++ % spawnPositions.Length;
            Vector3 spawnPos = spawnPositions[index];

            Instantiate(obstacle, spawnPos + spawnOffset, Quaternion.Euler(spawnRotation), transform);
            
            yield return _waitCooldown;
        }
        // ReSharper disable once IteratorNeverReturns
    }
    
}
