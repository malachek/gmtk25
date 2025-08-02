using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    //[SerializeField] EnemyBase[] enemyPrefabs;

    [SerializeField, Range(0.1f, 1f)] float SpawnRate;
    [SerializeField, Range(0.1f, .9f), Tooltip("x% obstacles, (1-x)% enemies")] float ObstacleToEnemyProportion;

    private int numObstaclePrefabVariants;
    //private float numEnemyPrefabVariants;

    private void Awake()
    {
        numObstaclePrefabVariants = obstaclePrefabs.Length;
    }

    public void SpawnPlatformObject(Transform parent, float spawnDegree, float spawnHeight)
    {
        if (Random.Range(0f, 1f) < ObstacleToEnemyProportion)
        {
            GameObject toInstantiate = obstaclePrefabs[Random.Range(0, numObstaclePrefabVariants)];
            GameObject instantiated = Instantiate(toInstantiate, Vector3.zero, Quaternion.Euler(0, (spawnDegree - 90f) % 360f, 0), parent);

            instantiated.transform.GetChild(0).GetComponentInChildren<ObstacleBase>().Initialize(spawnDegree, spawnHeight);
            Debug.Log($"Spawned {instantiated.name}");  
            //spawn Obstacle
        }
        else
        {
            //spawn Enemy
        }
    }
}
