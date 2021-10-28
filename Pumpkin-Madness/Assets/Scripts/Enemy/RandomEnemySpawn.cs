using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEnemySpawn : MonoBehaviour
{
    public bool shouldSpawn = true;
    public Enemy groundEnemy;
    public Enemy flyingEnemy;
    private GameObject[] spawnWalls;
    private GameObject player;

    private void Awake()
    {
        spawnWalls = GameObject.FindGameObjectsWithTag("SpawnWall");
        SpawnEnemies(shouldSpawn);
        InvokeRepeating(nameof(SpawnEnemy), 0.5f, 0.8f);
    }

    internal void SpawnEnemies(bool isToSpawn) {
        if (isToSpawn) player = GameObject.FindGameObjectWithTag("Player");
        shouldSpawn = isToSpawn;
    }
    
    private void SpawnEnemy()
    {
        if (!shouldSpawn || player == null) return;
        var enemy = Instantiate(groundEnemy);
        enemy.transform.position = GetRandomSpawnPosition();
    }
    
    private Vector3 GetRandomSpawnPosition()
    {
        var targetWall = spawnWalls[Random.Range(0, 2)];
        var targetBound = targetWall.GetComponent<SpriteRenderer>().bounds;
        var positionX = targetWall.transform.position.x;
        var y = Random.Range(0, targetBound.size.y);
        return new Vector3(positionX, y, 0);
    }
}
