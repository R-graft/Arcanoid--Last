using UnityEngine;

public class MainServiceLocator : MonoBehaviour
{
    public static MainServiceLocator Instance { get; private set; }

    private IServiceLocator<IService> _locator;

    private void Awake()
    {
        Instance = this;

        _locator = new ServiceLocator<IService>();

        var langHandler = new LangHandler();
        _locator.Regiser(langHandler);
    }

    public T GetService<T>() where T : IService
    {
        return _locator.Get<T>();
    }
}
