using UnityEngine;

public class LevelContext : MonoBehaviour
{
    [SerializeField] private SpawnSystem _spawnSystem;

    [SerializeField] private BlocksSystem _blocksSystem;

    [SerializeField] private BoostSystem _boostSystem;

    [SerializeField] private GameFieldSystem _gamefieldSystem;

    [SerializeField] private BlocksArrangeSystem _arrangeSystem;

    [SerializeField] private FieldGridSystem _fieldGridSystem;

    [SerializeField] private BallsController _ballController;

    [SerializeField] private PlatformController _platformController;

    [SerializeField] private BlocksDamageHandler _blocksDamage;
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
    }

    public T GetSystem<T>() where T : GameSystem
    {
        return _locator.Get<T>();
    }
}
