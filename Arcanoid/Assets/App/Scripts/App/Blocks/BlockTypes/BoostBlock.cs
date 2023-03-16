using UnityEngine;

public class BoostBlock : Block, IDamageable
{
    public Block Current => this;

    public void InDamage(int damageValue, out int currentHealth)
    {
        _healthCount -= damageValue;

        currentHealth = _healthCount;

        BoostEffect();
        
    }

    public void InDestroy()
    {
        _damageEffect.ClearEffect();

        BoostEffect();
    }

    public virtual void BoostEffect()
    {
    }
}
