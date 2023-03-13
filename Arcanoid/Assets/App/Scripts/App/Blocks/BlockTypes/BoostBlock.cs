using UnityEngine;

public class BoostBlock : Block, IDamageable
{
    [SerializeField]
    private int health;

    public int HealthCount { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override void InDamage(int damageValue)
    {
        HealthCount -= damageValue;

        if (HealthCount <= 0)
        {
            InDestroy();
        }

        else
        {
            base.InDamage(damageValue);

            BoostEffect();
        }
    }

    public override void InDestroy()
    {
        base.InDestroy();

        BoostEffect();
    }

    public virtual void BoostEffect()
    {
    }
}
