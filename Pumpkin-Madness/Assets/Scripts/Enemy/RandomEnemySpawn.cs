using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawn : MonoBehaviour
{
    // public bool shouldSpawn;
    // public Enemy[] enemyPrefabs;
    // public float[] moveSpeedRange;
    // public int[] healthRange;
    // private Bounds spawnArea;
    // private GameObject player;
    //
    // void Start () {
    //     spawnArea = this.GetComponent<BoxCollider>().bounds;
    //     SpawnEnemies(shouldSpawn);
    //     InvokeRepeating("spawnEnemy", 0.5f, 0.8f); // I tweaked the argument for repeatRate because I think the original spawn speed is too overwhelming
    // }
    //
    // void spawnEnemy() {
    //     if (!shouldSpawn || player == null) {
    //         return;
    //     }
    //
    //     int index = Random.Range(0, enemyPrefabs.Length);
    //     var newEnemy = Instantiate (enemyPrefabs[index], randomSpawnPosition (), Quaternion.identity) as Enemy;
    //     newEnemy.Initializer(player.transform, Random.Range (moveSpeedRange [0], moveSpeedRange [1]), Random.Range(healthRange[0], healthRange[1]));
    // }
    //
    // public void SpawnEnemies(bool shouldSpawn) {
    //     if (shouldSpawn) {
    //         player = GameObject.FindGameObjectWithTag("Player");
    //     }
    //     this.shouldSpawn = shouldSpawn;
    // }
    //
    // Vector3 randomSpawnPosition() {
    //     float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
    //     float z = Random.Range(spawnArea.min.z, spawnArea.max.z);
    //     float y = 0.5f;
    //     return new Vector3(x, y, z);
    // }
}
