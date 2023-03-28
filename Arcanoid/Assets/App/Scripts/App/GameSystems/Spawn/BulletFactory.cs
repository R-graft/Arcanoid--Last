using System;
using UnityEngine;

public class BulletFactory<T> : BaseMonoFactory<Bullet>
{
    public BulletFactory(Bullet prefab, Transform container): base(prefab, container)
    {
    }

    public override Bullet CreateObject()
    {
        var newBullet = base.CreateObject();

        newBullet.gameObject.SetActive(false);

        return newBullet;
    }

}
