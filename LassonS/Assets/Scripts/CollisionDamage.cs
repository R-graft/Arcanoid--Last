using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int dmg;

    public string tAg;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tAg) && collision.gameObject.TryGetComponent(out HP hp))
        {
            hp.Damage(dmg);
        }
    }
}
