using UnityEngine;
using Object = UnityEngine.Object;

public class BaseMonoFactory<T> : IPoolFactory<T> where T : BasePoolObject
{
    private readonly T _prefab;
    private readonly Transform _container;

    public BaseMonoFactory(T prefab, Transform container)
    {
        _prefab = prefab;
        _container = container;
    }
    public virtual T CreateObject()
    {
        return Object.Instantiate(_prefab, _container);
    }
}

public interface IPoolFactory<out T>
{
    T CreateObject();
}
