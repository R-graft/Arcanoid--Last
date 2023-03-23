using UnityEngine;

public class SimpleBlock : Block, IDamageable
{
    public Block Current { get => this;}
    public int CurrentHealth { get; set; }

    public override void Construct(string id, int health, Sprite sprite, Color effectColor)
    {
        base.Construct(id, health, sprite, effectColor);

        CurrentHealth = health;

        _damageEffect.CreateEffect(transform.position);
    }

    public override void RefreshBlock()
    {
        CurrentHealth = _startHealth;

        _damageEffect.ClearEffect();

        _collider.isTrigger = false;
    }

    public void InDamage(int damageValue, out int currentHealth)
    {
        CurrentHealth -= damageValue;

        currentHealth = CurrentHealth;

        _damageEffect.ApplyEffect();
    }

    public void InDestroy()
    {
        _damageEffect.ClearEffect();

        _destroyEffect.ApplyDestroy();
    }
}
