using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool Enemy;

    public HealthBarID HealthBarID;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthBarID.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        // if ()
        // {
        //     TakeDamage(20);
        // }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Enemy = GameObject.FindWithTag("Enemy").GetComponent<PolygonCollider2D>().isTrigger.Equals();
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBarID.SetHealth(currentHealth);
        if (currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }
    
}
