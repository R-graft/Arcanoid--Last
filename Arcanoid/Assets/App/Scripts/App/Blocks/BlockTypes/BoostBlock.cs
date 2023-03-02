using UnityEngine;

public class BoostBlock : Block, IDamageable
{
    [SerializeField]
    private int health;

   // public override int HealthCount { get; set; }

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

    public override void InAnimation()
    {
        base.InAnimation();

        HealthCount = health;
    }

    public virtual void BoostEffect()
    {
    }
}
