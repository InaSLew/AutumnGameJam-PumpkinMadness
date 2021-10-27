using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool Enemy;
    private bool isInvincible = false; 
    [SerializeField] private float invincibilityDurationSeconds;
    // [SerializeField] private float invincibilityDeltaTime;
    public HealthBarID HealthBarID;
    
    
    
    
    
    void Start()
    {
        currentHealth = maxHealth;
        HealthBarID.SetMaxHealth(maxHealth);
    }
    
    

    public void TakeDamage(int damage)
    {
        Debug.Log($"Player lost {damage} health!");
        
        if(isInvincible) return;
        currentHealth -= damage;
        HealthBarID.SetHealth(currentHealth);
        if (currentHealth<=0)
        {
            Destroy(gameObject);
        }
        // StartCoroutine(BecomeTemporarilyInvincible());
        MethodThatTriggersInvulnerability();
    }
    
    
    
    void MethodThatTriggersInvulnerability()
    {
        if (!isInvincible)
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }
    
    
    
    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;

        var temp = 0;
        for (float i = 0; i < invincibilityDurationSeconds; i += 0.2f)
        {
            // // Alternate between 0 and 1 scale to simulate flashing
            // if (gameObject.transform.localScale == Vector3.one)
            // {
            //     ScaleModelTo(Vector3.zero);
            //     Debug.Log("One");
            // }
            // else
            // {
            //     ScaleModelTo(Vector3.one);
            //     Debug.Log("two");
            // }

            if (temp == 4)
            {
                temp = 0;
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                temp++;
                ScaleModelTo(Vector3.one);
            }
            
            yield return new WaitForSeconds(0.5f);
        }
    
        Debug.Log("Player is no longer invincible!");
        ScaleModelTo(Vector3.one);
        isInvincible = false;
    }
    
    
    
    private void ScaleModelTo(Vector3 scale)
    {
        gameObject.transform.localScale = scale;
    }
    
    
}
