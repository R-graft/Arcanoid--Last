using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : IPool<T> where T : IPoolObject
{
    private readonly IPoolFactory<T> _factory;
    private readonly Queue<T> _queue;

    protected ObjectPool(IPoolFactory<T> factory)
    {
        _factory = factory;
        _queue = new Queue<T>();
    }
    public virtual T GetObject()
    {
        return _queue.Count > 0 ? _queue.Dequeue() : CreateObject();
    }

    public virtual void ReturnObject(T obj)
    {
        _queue.Enqueue(obj);
    }

    protected virtual T CreateObject()
    {
        var poolObject = _factory.CreateObject();
        poolObject.Initialize(this as IPool<IPoolObject>);
        return poolObject;
    }
}

public class BaseMonoPool<T> : ObjectPool<T> where T : BasePoolObject
{
    private readonly Transform _container;

    public BaseMonoPool(IPoolFactory<T> factory, Transform container) : base(factory)
    {
        _container = container;
    }

    public override void ReturnObject(T obj)
    {
        obj.transform.SetParent(_container);
        base.ReturnObject(obj);
    }
}

public abstract class BasePoolObject : MonoBehaviour, IPoolObject
{
    private IPool<IPoolObject> _pool;
    public virtual void Initialize(IPool<IPoolObject> pool)
    {
        _pool = pool;
    }

    public virtual void Return()
    {
        _pool.ReturnObject(this);
    }
}

public interface IPoolObject
{
    void Initialize(IPool<IPoolObject> pool);
    void Return();
}

public interface IPool<T>
{
    T GetObject();
    void ReturnObject(T obj);
}