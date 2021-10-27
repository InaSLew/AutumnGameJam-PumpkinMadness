using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEnemySpawn : MonoBehaviour
{
    public bool shouldSpawn;
    public Enemy enemyPrefab;
    private GameObject[] spawnWalls;
    private GameObject player;

    private void Awake()
    {
        spawnWalls = GameObject.FindGameObjectsWithTag("SpawnWall");
        SpawnEnemies(shouldSpawn);
        InvokeRepeating(nameof(SpawnEnemy), 0.5f, 0.8f);
    }

    internal void SpawnEnemies(bool isToSpawn) {
        Debug.Log("SpawnEnemies fires!!");
        if (isToSpawn) player = GameObject.FindGameObjectWithTag("Player");
        shouldSpawn = isToSpawn;
    }
    
    private void SpawnEnemy()
    {
        if (!shouldSpawn || player == null) return;

        Debug.Log("Start spawning enemies!!!!!");
    
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = GetRandomSpawnPosition();
    }
    
    private Vector3 GetRandomSpawnPosition()
    {
        var targetWall = spawnWalls[Random.Range(0, 1)];
        var targetBound = targetWall.GetComponent<SpriteRenderer>().bounds;
        var positionX = targetBound.size.x;
        var y = Random.Range(0, targetBound.size.y);
        return new Vector3(positionX, y, 0);
    }
}
