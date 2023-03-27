using UnityEngine;

public class BoostBlock : Block, IDamageable
{
    public Block Current => this;

    public int CurrentHealth { get; set; }

    public override void Construct(string id, int health, Sprite sprite, Color effectColor)
    {
        base.Construct(id, health, sprite, effectColor);

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

        _collider.isTrigger = false;
    }

    public void InDamage(int damageValue, out int currentHealth)
    {
        CurrentHealth -= damageValue;

        currentHealth = CurrentHealth;

        if (currentHealth == 0)
        {
            BoostEffect();
        }
    }

    public void InDestroy()
    {
        _destroyEffect.ApplyDestroy();
    }
}
