using System;
using UnityEngine;

public class BulletPool<T> : BaseMonoPool<Bullet> 
{
    public BulletPool(IPoolFactory<Bullet> factory, Transform container) : base(factory, container)
    {
    }

    public override Bullet GetObject()
    {
        var obj = base.GetObject();

        obj.gameObject.transform.parent = null;

        return obj;
    }

    public override void ReturnObject(Bullet obj)
    {
        base.ReturnObject(obj);
    }
}

