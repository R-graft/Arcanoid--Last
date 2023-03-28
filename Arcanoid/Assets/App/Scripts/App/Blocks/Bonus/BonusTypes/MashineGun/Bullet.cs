using System;
using UnityEngine;

public class Bullet : BasePoolObject
{
    [Header("config")]
    private const int _bulletSpeed = 8;

    private const int _bulletDamage = 1;

    [Header("components")]
    private BlocksDamageHandler _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _damage ??= LevelContext.Instance.GetSystem<BlocksDamageHandler>();

        if (collision.gameObject.TryGetComponent(out IDamageable dam))
        {
            _damage.SetDamage(dam, _bulletDamage);
        }

       gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.fixedDeltaTime);
    }
}
