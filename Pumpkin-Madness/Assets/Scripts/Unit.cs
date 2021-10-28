using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 0;
    [SerializeField] protected int DamagePower;
    
    
    protected Unit(int temp)
    {
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

    public virtual void TakeDamage(int value) => Health -= value;
    protected virtual void Attack(Unit target) => target.TakeDamage(target.DamagePower);
}
