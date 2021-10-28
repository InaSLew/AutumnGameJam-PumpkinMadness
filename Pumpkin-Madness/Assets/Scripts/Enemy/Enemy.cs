using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : Unit
{
    // public int MaxHealth;
    public Enemy() : base(4) {}

    public int SpawnId { get; }
    
    
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

    
    
    public override void TakeDamage(int value)
    {
        Debug.Log($"Enemy takes {value} damage!");
        base.TakeDamage(value);
        if (IsDead)
        {
            // TODO: Add caller to kill count here! --------------------------------------------------------------------
        }
    }
}
