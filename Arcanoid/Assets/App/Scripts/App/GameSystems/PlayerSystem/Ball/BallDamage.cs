using UnityEngine;

public class BallDamage : MonoBehaviour
{
    private int damageValue = 1;
    public bool TryDamage(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable dam))
        {
            dam.InDamage(damageValue);

            return true;
        }
        return false;
    }

    public void TryTriggerDamage(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable dam))
            dam.InDestroy();
    }

    public void SetDamage(int value) => damageValue = value;
}
