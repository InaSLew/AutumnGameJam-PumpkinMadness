using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class TemporaryEnemyProducerForPrefabTesting : MonoBehaviour
{
    public GameObject Weak_EnemyPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Weak_EnemyPrefab).transform.position = new Vector3(2f, -2f, 0f);
        Instantiate(Weak_EnemyPrefab).transform.position = new Vector3(2f, 3f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
