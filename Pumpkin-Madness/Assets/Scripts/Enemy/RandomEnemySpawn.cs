using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEnemySpawn : MonoBehaviour
{
    
    [SerializeField] private float GroundEnemySpawnInterval;
    [SerializeField] private float FlyEnemySpawnInterval;
    [SerializeField] private int ExtraGroundEnemyPer30Seconds;
    [SerializeField] private int ExtraFlyEnemyPer1Minute;
    [SerializeField] private Enemy groundEnemy;
    [SerializeField] private Enemy flyingEnemy;
    [SerializeField] private float PumpkinWallSpawnOffset;
    
    private int GroundEnemyCounter = 0;
    private int FlyingEnemyCounter = 0;
    private int GroundEnemyCap = 4;
    private int FlyEnemyCap = 2;
    
    private bool shouldSpawn = false;
    private GameObject[] spawnWalls;
    private GameObject[] spawnsInSky;
    private GameObject player;
    private float groundEnemySpawnTimer;
    private float flyEnemySpawnTimer;

    private void Awake()
    {
        PopulateAllSpawnCollections();
        InvokeRepeating(nameof(SpawnEnemy), 0.5f, 0.8f);
    }

    private void Update()
    {
        groundEnemySpawnTimer += Time.deltaTime;
        flyEnemySpawnTimer += Time.deltaTime;
        if (groundEnemySpawnTimer > GroundEnemySpawnInterval)
        {
            groundEnemySpawnTimer = 0f;
            ScaleGroundEnemySpawnRate();
        }

        if (flyEnemySpawnTimer > FlyEnemySpawnInterval)
        {
            flyEnemySpawnTimer = 0f;
            ScaleFlyEnemySpawnRate();
        }
    }

    private void ScaleFlyEnemySpawnRate()
    {
        if (!shouldSpawn || player == null) return;
        FlyEnemyCap += ExtraFlyEnemyPer1Minute;
        FlyingEnemyCounter = 0;
        SpawnFlyingEnemy();
    }
    
    private void ScaleGroundEnemySpawnRate()
    {
        if (!shouldSpawn || player == null) return;
        GroundEnemyCap += ExtraGroundEnemyPer30Seconds;
        GroundEnemyCounter = 0;
        SpawnGroundEnemy();
    }

    private void PopulateAllSpawnCollections()
    {
        spawnWalls = GameObject.FindGameObjectsWithTag("SpawnWall");
        spawnsInSky = GameObject.FindGameObjectsWithTag("SpawnSky");
    }

    internal void SpawnEnemies(bool isToSpawn) {
        if (isToSpawn) player = GameObject.FindGameObjectWithTag("Player");
        shouldSpawn = isToSpawn;
    }
    
    private void SpawnEnemy()
    {
        if (!shouldSpawn || player == null) return;
        if (GroundEnemyCounter < GroundEnemyCap) SpawnGroundEnemy();
        if (FlyingEnemyCounter < FlyEnemyCap) SpawnFlyingEnemy();
    }

    private void SpawnGroundEnemy()
    {
        for (var i = 0; i < GroundEnemyCap; i++)
        {
            var enemy = Instantiate(groundEnemy);
            enemy.transform.position = GetSpawnPositionFromSky();
            GroundEnemyCounter++;
        }
    }
    
    private void SpawnFlyingEnemy()
    {
        for (var i = 0; i < FlyEnemyCap; i++)
        {
            var enemy = Instantiate(flyingEnemy);
            enemy.transform.position = GetSpawnPositionFromWall();
            FlyingEnemyCounter++;
        }
    }

    private Vector3 GetSpawnPositionFromSky()
    {
        var index = Random.Range(0, 2);
        var targetSpawn = spawnsInSky[index];
        var position = targetSpawn.transform.position;
        var positionX = position.x;
        var positionY = position.y;
        return new Vector3(positionX, positionY, 0);
    }

    private Vector3 GetSpawnPositionFromWall()
    {
        // NOTE
        // Will clean this up after presentation, promise
        Vector3 result;
        var index = Random.Range(0, 2);
        if (index == 0) result =  new Vector3(-23f, 7f, 0);
        else result = new Vector3(19f, 7f, 0);
        return result;
    }

    private float GetPositionXWithOffset(int wallIndex, float position) =>
        wallIndex == 0 ? position - PumpkinWallSpawnOffset : position + PumpkinWallSpawnOffset;
}
