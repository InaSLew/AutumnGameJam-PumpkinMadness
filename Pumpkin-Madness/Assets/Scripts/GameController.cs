using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameController : MonoBehaviour
{
    public Random random = new Random();

    private RandomEnemySpawn randomEnemySpawn;

    private void Awake()
    {
        randomEnemySpawn = GetComponent<RandomEnemySpawn>();
    }

    private void Update()
    {
        throw new NotImplementedException();
    }
}
