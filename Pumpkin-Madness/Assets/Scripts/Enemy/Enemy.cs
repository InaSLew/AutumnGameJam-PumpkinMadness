using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : Unit
{
    // public int MaxHealth;
    public Enemy() : base() {}

    public int SpawnId { get; }
    private ScoreCounterUI scoreCounterUI;
    
    private GameObject player;
    void FindAndPlayParticle ()
    {
        // This makes every enemy explode on death
        ParticleSystem ps = GameObject.Find("PlayerWeapon").GetComponent<ParticleSystem>();
        ps.Play();
    }
    private void Awake()
    {      
        player = GameObject.FindGameObjectWithTag("Player");        
        // Make the player the target for the ai.
        if (TryGetComponent(out AIDestinationSetter destinationSetter))
            destinationSetter.target = player.transform;

        Debug.Log(IsDead);
    }

    
    
    private void OnTriggerStay2D(Collider2D triggerCollider)
    {
        if (triggerCollider.gameObject == player)
        {
            player.GetComponent<Player>().TakeDamage(DamagePower);
        }
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
        base.TakeDamage(value);
        
        if (IsDead)
        {
            ScoreCounterUI.instance.AddKill();
            FindAndPlayParticle();
            // TODO: Add caller to kill count here! --------------------------------------------------------------------
        }
    }
}
