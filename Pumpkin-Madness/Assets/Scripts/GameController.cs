using UnityEngine;

public class GameController : MonoBehaviour
{
    private RandomEnemySpawn randomEnemySpawn;

    private void Awake()
    {
        randomEnemySpawn = GetComponent<RandomEnemySpawn>();
        
    }

    private void Update()
    {
        randomEnemySpawn.SpawnEnemies(true);
    }
}
