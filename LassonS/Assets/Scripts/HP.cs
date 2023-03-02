using System;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hp;

    public Action getDamage;

    public void Damage(int dmg)
    {
        hp -= dmg;

        getDamage.Invoke();

        if (hp <= 0 )
        {
            Destroy(gameObject);
        }

    }
}
