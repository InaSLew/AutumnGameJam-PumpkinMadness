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
        gameObject.GetComponent<AIDestinationSetter>().target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            // Deal damage to player.
            // player.dealdamage(damagePower);
            player.GetComponent<Player>().TakeDamage(DamagePower);
        }
    }
}
