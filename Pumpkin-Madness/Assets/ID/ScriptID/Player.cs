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
    [SerializeField] private float invincibilityDeltaTime;
    [SerializeField] private GameObject model;

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

    public void TakeDamage(int damage)
    {
        if(isInvincible) return;
        currentHealth -= damage;
        HealthBarID.SetHealth(currentHealth);
        if (currentHealth<=0)
        {
            Destroy(gameObject);
        }
        StartCoroutine(BecomeTemporarilyInvincible());
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

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            // Alternate between 0 and 1 scale to simulate flashing
            if (model.transform.localScale == Vector3.one)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(Vector3.one);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        Debug.Log("Player is no longer invincible!");
        ScaleModelTo(Vector3.one);
        isInvincible = false;
    }
    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }
    
    
}
