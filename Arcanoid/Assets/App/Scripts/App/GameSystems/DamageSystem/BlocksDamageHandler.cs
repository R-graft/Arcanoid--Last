using UnityEngine;

public class BlocksDamageHandler : GameSystem
{
    private BlocksSystem _blocks;

    public override void InitSystem()
    {
        _blocks = LevelContext.Instance.GetSystem<BlocksSystem>();
    }

    public void SetDamage(IDamageable dam, int damageValue)
    {
        dam.InDamage(damageValue, out int currentHealth);

        if (currentHealth == 0)
        {
            dam.InDestroy();

            _blocks.RemoveBlock(dam.Current);
        }
    }
}

public interface IDamageable
{
    public Block Current {get;}
    public void InDestroy();
    public void InDamage(int damageValue, out int health);
}