using UnityEngine;

public class EnemyDamageEddect : MonoBehaviour
{
    public ParticleSystem bloodPart;

    public HP enemyHp;

    public AudioSource punchSfx;

    public Animation death;

    private void InPunch()
    {
        punchSfx.Play();

        bloodPart.Play();
    }

    private void InDeath()
    {

    }
    private void OnEnable()
    {
        enemyHp.getDamage += InPunch;
    }

    private void OnDisable()
    {
        enemyHp.getDamage -= InPunch;
    }
}
