using UnityEngine;

public class SimpleBlock : Block, IDamageable
{
    public Block Current { get => this; set => throw new System.NotImplementedException(); }

    public void InDamage(int damageValue, out int currentHealth)
    {
        _healthCount -= damageValue;

        currentHealth = _healthCount;

        _damageEffect.ApplyEffect();
    }

    public void InDestroy()
    {
        _damageEffect.ClearEffect();

        //Return();
    }
}
