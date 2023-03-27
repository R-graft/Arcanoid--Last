using System;
using UnityEngine;

public class Bullet : BasePoolObject
{
    [Header("config")]
    private const int _bulletSpeed = 8;

    private const int _bulletDamage = 1;

    [Header("components")]
    private BlocksDamageHandler _damage;

    public Action<Bullet> OnRemove;

    public void Construct(BlocksDamageHandler damage, Action onRemove)
    {
        _damage = damage;

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
        OnRemove(this);
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * _bulletSpeed * Time.fixedDeltaTime);
    }

    public override void Initialize(IPool<IPoolObject> pool)
    {
        base.Initialize(pool);
    }
}
