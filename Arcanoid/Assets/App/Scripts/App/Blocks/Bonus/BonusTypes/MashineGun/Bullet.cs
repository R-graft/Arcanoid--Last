using System;
using UnityEngine;

public class Bullet : BasePoolObject
{
    [Header("config")]
    private const int _bulletSpeed = 8;

    private const int _bulletDamage = 1;

    [Header("components")]
    private BlocksDamageHandler _damage;

    private ObjectPool<Bullet> _pool;

    public void Construct(BlocksDamageHandler damage, ObjectPool<Bullet> pool, Action onRemove)
    {
        _damage = damage;

        _pool = pool;

        onRemove += Remove;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable dam))
        {
            _damage.SetDamage(dam, _bulletDamage);
        }

        Remove();
    }

    private void Remove()
    {
        _pool.ReturnObject(this);
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.fixedDeltaTime);
    }
}
