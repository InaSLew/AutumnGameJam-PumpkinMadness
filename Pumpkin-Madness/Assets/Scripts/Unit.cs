using System;
using System.Collections;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    [SerializeField] protected int DamagePower;
    [SerializeField] private Sprite regularSprite;
    [SerializeField] private Sprite damageTakenSprite;
    [SerializeField] private float invulnerabilityTime;
    [SerializeField] private float redFlashDuration;

    
    
    private SpriteRenderer spriteRenderer;
    private bool isInvulnerable;
    
    
    protected Unit()
    {
    }

    
    
    private void Start()
    {
        health = MaxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    
    
    public bool IsAlive => health > 0;
    public bool IsDead => !IsAlive;
    private int health;
    protected int Health
    {
        private get => health;
        set
        {
            health = Mathf.Clamp(value, 0, MaxHealth);
            if (IsDead)
            {
                Destroy(this.gameObject);
            }
        } 
    }
    
    

    public virtual void TakeDamage(int value)
    {
        if (!isInvulnerable)
        {


            Health -= value;
            isInvulnerable = true;

            if (IsAlive)
            {
                StartCoroutine(DamageFlashIndicator());
                Invoke(nameof(InvulnerabilityCooldown), invulnerabilityTime);
            }
        }
    }
    
    
    protected virtual void Attack(Unit target) => target.TakeDamage(target.DamagePower);



    IEnumerator DamageFlashIndicator()
    {
        spriteRenderer.sprite = damageTakenSprite;
        yield return new WaitForSeconds(redFlashDuration);
        spriteRenderer.sprite = regularSprite;
    }
    


    void InvulnerabilityCooldown()
    {
        isInvulnerable = false;
    }
}
