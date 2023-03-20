using UnityEngine;

public class BoostBlock : Block, IDamageable
{
    public Block Current => this;

    public int CurrentHealth { get; set; }

    public override void Construct(string id, int health, Sprite sprite)
    {
        base.Construct(id, health, sprite);

        CurrentHealth = health;
    }

    protected void Start()
    {
        InitBoost();
    }

    protected virtual void InitBoost()
    {
    }

    public virtual void BoostEffect()
    {
    }

    public override void RefreshBlock()
    {
        CurrentHealth = _startHealth;
    }

    public void InDamage(int damageValue, out int currentHealth)
    {
        CurrentHealth -= damageValue;

        currentHealth = CurrentHealth;

        if (CurrentHealth != 0)
        {
            BoostEffect();
        }
    }

    public void InDestroy()
    {

        BoostEffect();
    }
}
