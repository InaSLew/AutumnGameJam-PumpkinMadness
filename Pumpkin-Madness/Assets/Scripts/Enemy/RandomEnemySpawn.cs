using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEnemySpawn : MonoBehaviour
{
    public static int GroundEnemyCounter = 0;
    public static int FlyingEnemyCounter = 0;
    public static int TotalEnemyCap = 10;
    public static int GroundEnemyCap = Convert.ToInt32(TotalEnemyCap * 0.6);
    public static int FlyEnemyCap = Convert.ToInt32(TotalEnemyCap * 0.4);
    
    public bool shouldSpawn = false;
    public Enemy groundEnemy;
    public Enemy flyingEnemy;
    private GameObject[] spawnWalls;
    private GameObject[] spawnsInSky;
    private GameObject player;
    // private const int TutorialPhaseGroundEnemyCap = 3;
    // private const int TutorialPhaseFlyingEnemyCap = 2;
    private const float PumpkinWallSpawnOffset = 1.5f;

    private void Awake()
    {
        PupulateAllSpawnCollectoins();
        InvokeRepeating(nameof(SpawnEnemy), 0.5f, 0.8f);
    }

    private void PupulateAllSpawnCollectoins()
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
            Debug.Log("Ground enemy instantiated!!");
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
        var index = Random.Range(0, 2);
        var targetSpawn = spawnWalls[index];
        var targetBound = targetSpawn.GetComponent<SpriteRenderer>().bounds;
        var positionX = targetSpawn.transform.position.x;
        var y = Random.Range(0, targetBound.size.y / 3);
        return new Vector3(GetPositionXWithOffset(index, positionX), y, 0);
    }

    private float GetPositionXWithOffset(int wallIndex, float position) =>
        wallIndex == 0 ? position + PumpkinWallSpawnOffset : position - PumpkinWallSpawnOffset;
}
