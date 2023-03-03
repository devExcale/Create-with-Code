using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] enemyPrefabs;
    [SerializeField]
    private GameObject bossPrefab;
    [SerializeField]
    private GameObject[] powerupPrefabs;

    [SerializeField]
    private Vector2 rangeX = Vector2.zero;
    [SerializeField]
    private Vector2 rangeZ = Vector2.zero;

    private Transform _enemyContainer;
    private Transform _powerupContainer;

    public int WaveNumber { get; private set; } = 0;

    private void Start()
    {

        Transform thisTransform = transform;
        Vector3 thisPosition = thisTransform.position;
        
        _enemyContainer = transform.Find("Enemies");
        if (_enemyContainer == null)
            _enemyContainer = Instantiate(new GameObject("Enemies"), thisPosition, Quaternion.identity, thisTransform).transform;
        
        _powerupContainer = transform.Find("Powerups");
        if (_powerupContainer == null)
            _powerupContainer = Instantiate(new GameObject("Powerups"), thisPosition, Quaternion.identity, thisTransform).transform;

    }

    private void Update()
    {
        int enemyCount = _enemyContainer.childCount;

        if (enemyCount == 0)
            DoNewWave();
    }

    public Vector3 RandomPosition()
    {
        float x = Random.Range(rangeX.x, rangeX.y);
        float z = Random.Range(rangeZ.x, rangeZ.y);
        return new Vector3(x, 0f, z);
    }

    private void DoNewWave()
    {
        WaveNumber++;
        
        SpawnPowerup();

        if (Random.Range(0f, 100f) <= 20f)
            SpawnBoss();
        else
            SpawnEnemyWave(WaveNumber);
    }

    private void SpawnPowerup()
    {
        int powerupIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerupIndex], RandomPosition(), Quaternion.identity, _powerupContainer);
    }

    private void SpawnEnemyWave(int enemies)
    {
        for (int i = 0; i < enemies; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], RandomPosition(), Quaternion.identity, _enemyContainer);
        }
    }

    private void SpawnBoss()
    {
        Vector3 pos = RandomPosition();
        pos.y = bossPrefab.transform.position.y;

        Instantiate(bossPrefab, pos, Quaternion.identity, _enemyContainer);
    }
    
}
