using UnityEngine;

public abstract class AbstractFactory<T>
{
    public abstract T CreateObject();
}
