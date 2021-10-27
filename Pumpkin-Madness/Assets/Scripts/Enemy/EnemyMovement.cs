using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform playerTargetPosition;

    public float MovementSpeed;
    
    void Start()
    {
        playerTargetPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, playerTargetPosition.position, Time.deltaTime * MovementSpeed);
    }
}
