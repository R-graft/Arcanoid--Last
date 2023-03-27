using UnityEngine;

public class NonDamageBlock : Block, IDamageable
{
    public Block Current => this;

    public int CurrentHealth { get ; set;}

    public void InDamage(int damageValue, out int health)
    {
        health = 1;
    }

    public void InDestroy()
    {
    }

    public override void RefreshBlock()
    {
    }
}
