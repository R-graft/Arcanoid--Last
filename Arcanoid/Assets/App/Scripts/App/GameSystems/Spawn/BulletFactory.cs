using System;
using UnityEngine;

public class BulletFactory<T> : BaseMonoFactory<Bullet>
{
    private BlocksDamageHandler _damage;

    private Action OnRemove;

    public BulletFactory(Bullet prefab, Transform container, BlocksDamageHandler damage, Action onRemove): base(prefab, container)
    {
        _damage = damage;

        OnRemove = onRemove;
    }

    public override Bullet CreateObject()
    {
        var newBullet = base.CreateObject();

        newBullet.Construct(_damage, OnRemove);

        return newBullet;
    }

}
