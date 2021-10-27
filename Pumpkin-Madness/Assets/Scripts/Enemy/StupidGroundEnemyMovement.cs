using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidGroundEnemyMovement : MonoBehaviour
{
    private Transform playerTargetPosition;

    public float MovementSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerTargetPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, playerTargetPosition.position, Time.deltaTime * MovementSpeed);
    }
}
