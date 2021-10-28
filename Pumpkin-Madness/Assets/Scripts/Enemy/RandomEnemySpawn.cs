using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEnemySpawn : MonoBehaviour
{
    public static int GroundEnemyCounter = 0;
    public static int FlyingEnemyCounter = 0;
    
    public bool shouldSpawn = false;
    public Enemy groundEnemy;
    public Enemy flyingEnemy;
    private GameObject[] spawnWalls;
    private GameObject player;
    private const int TutorialPhaseGroundEnemyCap = 50;
    private const float GroundEnemySpawnOffset = 1.5f;
    private const int TutorialPhaseFlyingEnemyCap = 50;

    private void Awake()
    {
        spawnWalls = GameObject.FindGameObjectsWithTag("SpawnWall");
        InvokeRepeating(nameof(SpawnEnemy), 0.5f, 0.8f);
    }

    internal void SpawnEnemies(bool isToSpawn) {
        if (isToSpawn) player = GameObject.FindGameObjectWithTag("Player");
        shouldSpawn = isToSpawn;
    }
    
    private void SpawnEnemy()
    {
        if (!shouldSpawn || player == null) return;
        if (GroundEnemyCounter < TutorialPhaseGroundEnemyCap) SpawnGroundEnemy();
        if (FlyingEnemyCounter < TutorialPhaseFlyingEnemyCap) SpawnFlyingEnemy();
    }

    private void SpawnFlyingEnemy()
    {
        var enemy = Instantiate(flyingEnemy);
        enemy.transform.position = GetRandomSpawnPosition();
        FlyingEnemyCounter++;
    }

    private void SpawnGroundEnemy()
    {
        var enemy = Instantiate(groundEnemy);
        enemy.transform.position = GetRandomSpawnPosition();
        GroundEnemyCounter++;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        var index = Random.Range(0, 2);
        var targetWall = spawnWalls[index];
        var targetBound = targetWall.GetComponent<SpriteRenderer>().bounds;
        var positionX = targetWall.transform.position.x;
        var y = Random.Range(0, targetBound.size.y / 3);
        return new Vector3(GetPositionXWithOffset(index, positionX), y, 0);
    }

    private float GetPositionXWithOffset(int wallIndex, float position) =>
        wallIndex == 0 ? position + GroundEnemySpawnOffset : position - GroundEnemySpawnOffset;
}
