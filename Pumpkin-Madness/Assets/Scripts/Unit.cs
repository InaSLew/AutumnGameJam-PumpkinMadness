using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected Unit(int maxHealth, int damagePower)
    {
        MaxHealth = maxHealth;
        DamagePower = damagePower;
        health = MaxHealth;
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
                Destroy(this.gameObject);
        } 
    }
    protected int MaxHealth { get; }
    protected int DamagePower { get; }

    public virtual void TakeDamage(int value) => Health -= value;
    protected virtual void Attack(Unit target) => target.TakeDamage(target.DamagePower);
}
