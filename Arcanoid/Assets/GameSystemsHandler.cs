using UnityEngine;

public class GameSystemsHandler : MonoBehaviour, IGameHandler
{
    [SerializeField] private SpawnSystem _spawnSystem;

    [SerializeField] private BlocksSystem _blocksSystem;

    [SerializeField] private PlatformController _platformController;

    [SerializeField] private BallsController _ballController;

    [SerializeField] private BoostSystem _boostSystem;

    [SerializeField] private GameFieldSystem _gamefieldSystem;

    [SerializeField] private BlocksArrangeSystem _arrangeSystem;

    [SerializeField] private FieldGridSystem _fieldGridSystem;

    private Inputs _inputs;

    private LevelController _levelController;

    public void InitController(LevelController controller)
    {
        _levelController = controller;
    }

    public void InitSystems(Inputs inputs)
    {
        _inputs = inputs;

        _fieldGridSystem.Init();

        _inputs.TurnOff(false);

        _spawnSystem.Init();

        _blocksSystem.Init();

        _platformController.Init();

        _ballController.Init();

        _gamefieldSystem.Init();
    }

    public void StartGame()
    {
        _blocksSystem.StartSystem();

        _inputs.TurnOn(false);
    }

    public void RestartGame()
    {
        _ballController.RestartSystem();

        _platformController.RestartSystem();

        _inputs.TurnOn(false);
    }

    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;

            _inputs.TurnOn(false);
        }

        else
        {
            _inputs.TurnOff(false);

            Time.timeScale = 0;
        }
    }

    public void LoseGame()
    {
        _inputs.TurnOff(false);

        _ballController.StopBalls();

        _boostSystem.StopSystem();
    }

    public void WinGame()
    {
        _inputs.TurnOff(false);

        _ballController.StopBalls();

        _boostSystem.StopSystem();
    }
}
