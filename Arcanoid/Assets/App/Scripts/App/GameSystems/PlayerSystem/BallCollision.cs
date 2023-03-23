using System;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private BallSpeed _speed;

    [SerializeField] private BallBounce _bounce;

    private BlocksDamageHandler _blocksDamage;

    private const int BallDamageValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_blocksDamage)
        {
            _blocksDamage = LevelContext.Instance.GetSystem<BlocksDamageHandler>();
        }

        if (collision.gameObject.TryGetComponent(out IDamageable dam))
        {
            _blocksDamage.SetDamage(dam, BallDamageValue);

            _speed.CollisionSpeed();
        }

        _bounce.TryAngleCorrect(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_blocksDamage)
        {
            _blocksDamage = LevelContext.Instance.GetSystem<BlocksDamageHandler>();
        }

        if (collision.gameObject.TryGetComponent(out IDamageable dam))
        {
            _blocksDamage.SetDestroy(dam);
        }
    }
}
