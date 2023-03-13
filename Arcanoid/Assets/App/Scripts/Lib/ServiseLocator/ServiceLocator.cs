using System;
using System.Collections.Generic;

public class ServiceLocator<T> : IServiceLocator<T>
{
    protected Dictionary<Type, T> _serviceMap;

    public ServiceLocator()
    {
        _serviceMap = new Dictionary<Type, T>();
    }
    public TP Get<TP>() where TP : T
    {
        var type = typeof(TP);

        if (!_serviceMap.ContainsKey(type))
        {
            throw new Exception($"Cannot get service{type}");
        }

        return (TP)_serviceMap[type];
    }

    public TP Regiser<TP>(TP newService) where TP : T
    {
        var type = newService.GetType();

        if (_serviceMap.ContainsKey(type))
        {
            throw new Exception($"Cannot add service{type}");
        }

        _serviceMap.Add(type, newService);

        return newService;
    }

    public void Unregister<TP>(TP newService) where TP : T
    {
        var type = newService.GetType();

        if (_serviceMap.ContainsKey(type))
        {
            _serviceMap.Remove(type);
        }
    }
}

public interface IServiceLocator<T>
{
    TP Regiser<TP>(TP newService) where TP : T;
    void Unregister<TP>(TP newService) where TP : T;
    TP Get<TP>() where TP : T;
}
