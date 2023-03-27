using UnityEngine;

public class BulletPool<T> : BaseMonoPool<Bullet> 
{
    public BulletPool(IPoolFactory<Bullet> factory, Transform container) : base(factory, container)
    {
    }

    public override Bullet GetObject()
    {
        var obj = base.GetObject();

        obj.OnRemove += ReturnObject;

        obj.gameObject.transform.parent = null;

        return obj;
    }
}

