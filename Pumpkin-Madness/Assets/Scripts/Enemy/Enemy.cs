using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : Unit
{
    public Enemy() : base(1, 10) {}

    private GameObject player;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        // Make the player the target for the ai.
        if (TryGetComponent(out AIDestinationSetter destinationSetter))
            destinationSetter.target = player.transform;
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.gameObject == player)
        {
            player.GetComponent<Player>().TakeDamage(DamagePower);
        }
    }
}
