using UnityEngine;

public class LevelContext : MonoBehaviour
{
    [SerializeField] private SpawnSystem _spawnSystem;

    [SerializeField] private BlocksSystem _blocksSystem;

    [SerializeField] private BonusSystem _bonusSystem;

    [SerializeField] private BlocksArrangeSystem _arrangeSystem;

    [SerializeField] private FieldGridSystem _fieldGridSystem;

    [SerializeField] private BallsController _ballController;

    [SerializeField] private PlatformController _platformController;

    [SerializeField] private BlocksDamageHandler _blocksDamage;

    [SerializeField] private GamePanelController _gamePanelController;
    public static LevelContext Instance { get; private set; }

    private IServiceLocator<GameSystem> _locator;

    public void InitContext()
    {
        Instance = this;

        _locator = new ServiceLocator<GameSystem>();

        _locator.Regiser(_ballController);

        _locator.Regiser(_platformController);

        _locator.Regiser(_fieldGridSystem);

        _locator.Regiser(_spawnSystem);

        _locator.Regiser(_blocksSystem);

        _locator.Regiser(_blocksDamage);

        _locator.Regiser(_arrangeSystem);

        _locator.Regiser(_bonusSystem);

        _locator.Regiser(_gamePanelController);
        
    }

    public T GetSystem<T>() where T : GameSystem
    {
        return _locator.Get<T>();
    }
}
