using UnityEngine;

public class SimpleBlock : Block, IDamageable
{
    [SerializeField]
    private ColoredBlock _coloredBlock;

    [SerializeField]
    private int health;
    //public override int HealthCount { get; set; }

    public override void InDamage(int damageValue)
    {
        HealthCount-= damageValue;

        if (HealthCount <= 0)
        {
            InDestroy();
        }

        else
        {
            base.InDamage(damageValue);

            _coloredBlock.SetColor(_blockSprite, HealthCount);
        }
    }
    public override void InAnimation()
    {
        base.InAnimation();

        HealthCount = health;

        _coloredBlock.SetColor(_blockSprite, HealthCount);
    }
}
