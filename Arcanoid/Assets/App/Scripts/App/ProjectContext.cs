using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    [SerializeField] private UIPopUpController _popUpHandler;

    [SerializeField] private Inputs _inputHandler;

    [SerializeField] private ScenesManager _scenesHandler;

    public static ProjectContext Instance { get; private set; }

    public IServiceLocator<IService> _locator;

    public void InitContext()
    {
        Instance = this;

        _locator = new ServiceLocator<IService>();

        var langHandler = new LangHandler();
        _locator.Regiser(langHandler);
        InitService(langHandler);

        var packController = new PackDataController();
        _locator.Regiser(packController);
        InitService(packController);

        var energyCounter = new EnergyCounter();
        _locator.Regiser(energyCounter);
        InitService(energyCounter);

        _popUpHandler = Instantiate(_popUpHandler);
        _locator.Regiser(_popUpHandler);
        InitService(_popUpHandler);

        _inputHandler= Instantiate(_inputHandler);
        _locator.Regiser(_inputHandler);
        InitService(_inputHandler);

        _scenesHandler = Instantiate(_scenesHandler);
        _locator.Regiser(_scenesHandler);
        InitService(_scenesHandler);
    }

    public T GetService<T>() where T : IService
    {
        return _locator.Get<T>();
    }

    public void InitService(IService service)
    {
        service.Init();
    }
}
