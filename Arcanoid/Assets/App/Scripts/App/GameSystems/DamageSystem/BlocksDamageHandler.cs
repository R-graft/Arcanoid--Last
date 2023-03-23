using System.Collections;
using System.Collections.Generic;
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
                SetDestroy(dam);
            }
        }
    }

    public void SetDestroy(IDamageable dam)
    {
        dam.InDestroy();

        _blocks.RemoveBlock(dam.Current);
    }

    public void SetArrayDamage(List<IDamageable> damagingArray, int damage, float damagingHold)
    {
        StartCoroutine(ArrayDestroy(damagingArray, damage, damagingHold));
    }

    private IEnumerator ArrayDestroy(List<IDamageable> damagingArray, int damage, float damagingHold)
    {
        int count = damagingArray.Count-1;

        while (count >= 0)
        {
            yield return new WaitForSeconds(damagingHold);

            SetDamage(damagingArray[count], damage);

            count--;
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