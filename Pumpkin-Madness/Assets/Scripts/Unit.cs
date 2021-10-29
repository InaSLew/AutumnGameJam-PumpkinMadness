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
    [SerializeField] private Material hurtParticle;
    [SerializeField] private Material deathParticle;

    private ParticleSystemRenderer particleSystemRenderer;
    private ParticleSystem particleSystem;
    private SpriteRenderer spriteRenderer;
    private bool isInvulnerable;
    
    
    protected Unit()
    {
    }

    
    
    private void Start()
    {
        health = MaxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        particleSystem = GetComponent<ParticleSystem>();
        particleSystemRenderer = GetComponent<ParticleSystemRenderer>();
        
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
            PlayHurtParticle();


            Health -= value;
            isInvulnerable = true;

            if (IsAlive)
            {
                PlayHurtParticle();
                StartCoroutine(DamageFlashIndicator());
                Invoke(nameof(InvulnerabilityCooldown), invulnerabilityTime);
            }
            else
            {
                PlayDeathParticle();
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



    void PlayHurtParticle()
    {
        particleSystem.Stop();
        particleSystemRenderer.material = hurtParticle;
        particleSystem.Play();
    }

    void PlayDeathParticle()
    {
        particleSystem.Stop();
        particleSystemRenderer.material = deathParticle;
        particleSystem.Play();
    }
    
    
    
    void InvulnerabilityCooldown()
    {
        isInvulnerable = false;
    }
}
