using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryEnemyProducerForPrefabTesting : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(EnemyPrefabs[0]).transform.position = new Vector3(2f, 4f, 0f);
        Instantiate(EnemyPrefabs[1]).transform.position = new Vector3(2f, 3f, 0f);
        Instantiate(EnemyPrefabs[0]).transform.position = new Vector3(-2f, 4f, 0f);
        Instantiate(EnemyPrefabs[1]).transform.position = new Vector3(-2f, 3f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
