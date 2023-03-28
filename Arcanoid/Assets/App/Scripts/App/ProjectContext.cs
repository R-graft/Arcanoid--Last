using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    [SerializeField] private UIPopUpController _popUpHandler;

    [SerializeField] private Inputs _inputHandler;

    [SerializeField] private ScenesManager _scenesHandler;

    [SerializeField] private PackDataController _packDataController;

    public static ProjectContext Instance { get; private set; }

    private IServiceLocator<IService> _locator;

    public void InitContext()
    {
        Instance = this;

        _locator = new ServiceLocator<IService>();

        var langHandler = new LangHandler();
        _locator.Regiser(langHandler).InitService();

        var energyCounter = new EnergyCounter();
        _locator.Regiser(energyCounter).InitService();

        var animator = new AnimateHandler();
        _locator.Regiser(animator).InitService();

        var levelController = new LevelController();
        _locator.Regiser(levelController).InitService();

        _packDataController = Instantiate(_packDataController);
        _locator.Regiser(_packDataController).InitService();

        _scenesHandler = Instantiate(_scenesHandler);
        _locator.Regiser(_scenesHandler).InitService();

        _popUpHandler = Instantiate(_popUpHandler);
        _locator.Regiser(_popUpHandler).InitService();

        _inputHandler = Instantiate(_inputHandler);
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
