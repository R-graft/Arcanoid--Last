using UnityEngine;

public class BulletPool<T> : BaseMonoPool<Bullet> 
{
    private Transform _container;
    public BulletPool(IPoolFactory<Bullet> factory, Transform container) : base(factory, container)
    {
    }

    public override Bullet GetObject()
    {
        var obj = base.GetObject();

        obj.gameObject.SetActive(true);

        obj.gameObject.transform.parent = null;

        return obj;
    }

    public override void ReturnObject(Bullet obj)
    {
        obj.transform.SetParent(_container);
        obj.gameObject.SetActive(false);
        base.ReturnObject(obj);
    }
}

