using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : Unit
{
    // public int MaxHealth;
    public Enemy() : base() {}

    public int SpawnId { get; }
    
    [SerializeField] private Material deathParticle;

    private GameObject player;
    private ParticleSystem ps;
    private ParticleSystemRenderer psr;

    void FindAndPlayParticle ()
    {
        // This makes every enemy explode on death

        psr.material = deathParticle;
        ps.Play();
    }


    private void Awake()
    {      
        player = GameObject.FindGameObjectWithTag("Player");        
        // Make the player the target for the ai.
        if (TryGetComponent(out AIDestinationSetter destinationSetter))
            destinationSetter.target = player.transform;
        
        
        ps = GameObject.Find("PlayerWeapon").GetComponent<ParticleSystem>();
        psr = GameObject.Find("PlayerWeapon").GetComponent<ParticleSystemRenderer>();
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
            FindAndPlayParticle();
            
            // TODO: Add caller to kill count here! --------------------------------------------------------------------
        }
    }
}
