using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    [SerializeField] private UIPopUpController _popUpHandler;

    [SerializeField] private Inputs _inputHandler;

    [SerializeField] private ScenesManager _scenesHandler;

    [SerializeField] private PackDataController _packDataController;

    [SerializeField] private LangHandler _langHandler;

    public static ProjectContext Instance { get; private set; }

    private IServiceLocator<IService> _locator;

    public void InitContext()
    {
        Instance = this;

        _locator = new ServiceLocator<IService>();

        var energyCounter = new EnergyCounter();
        _locator.Regiser(energyCounter).InitService();

        _langHandler = Instantiate(_langHandler);
        _locator.Regiser(_langHandler).InitService();

        _packDataController = Instantiate(_packDataController);
        _locator.Regiser(_packDataController).InitService();

        _scenesHandler = Instantiate(_scenesHandler);
        _locator.Regiser(_scenesHandler).InitService();

        _popUpHandler = Instantiate(_popUpHandler);
        _locator.Regiser(_popUpHandler).InitService();

        _inputHandler= Instantiate(_inputHandler);
        _locator.Regiser(_inputHandler).InitService();
    }

    public T GetService<T>() where T : IService
    {
        return _locator.Get<T>();
    }

    public void AddService(IService service)
    {
        _locator.Regiser(service).InitService();
    }
}
