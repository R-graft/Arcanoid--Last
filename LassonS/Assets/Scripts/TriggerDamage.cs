using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public int dmg;

    public string tAg;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(tAg) && collider.gameObject.TryGetComponent(out HP hp))
        {
            hp.Damage(dmg);
        }
    }
}

