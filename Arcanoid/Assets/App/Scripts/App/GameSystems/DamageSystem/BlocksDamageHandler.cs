public class BlocksDamageHandler : GameSystem
{
    private BlocksSystem _blocks;

    public override void InitSystem()
    {
        _blocks = LevelContext.Instance.GetSystem<BlocksSystem>();
    }

    public void SetDamage(IDamageable dam, int damageValue)
    {
        if (damageValue < 0)
        {
            dam.InDestroy();

            _blocks.RemoveBlock(dam.Current);
        }

        else
        {
            dam.InDamage(damageValue, out int currentHealth);

            if (currentHealth == 0)
            {
                dam.InDestroy();

                _blocks.RemoveBlock(dam.Current);
            }
        }
    }
}

public interface IDamageable
{
    public Block Current {get;}

    public int CurrentHealth { get; set; }
    public void InDestroy();
    public void InDamage(int damageValue, out int health);
}