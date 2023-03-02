using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private SpawnSystem _spawnSystem;

    [SerializeField] private BlocksSystem _blocksSystem;

    [SerializeField] private PlatformController _platformController;

    [SerializeField] private BallsController _ballController;

    [SerializeField] private BoostSystem _boostSystem;

    [SerializeField] private GameFieldSystem _gamefieldSystem;

    [SerializeField] private GamePanelController _gamePanelController;

    [SerializeField] private GameUI _GameUI;

    private Inputs _inputs;

    private void Awake()
    {
        SubscribeOnUI();

        InitLevel();
    }

    private void InitLevel()
    {
        _inputs = Inputs.Instance;

        _inputs.TurnOff(false);

        _spawnSystem.Init();

        _blocksSystem.Init();

        _platformController.Init();

        _ballController.Init();

        _gamefieldSystem.Init();

        _GameUI.Init();

        StartGame();
    }

    public void StartGame()
    {
        GameProgressController.Instance.LoadLevel();

        _blocksSystem.StartSystem();

        _gamePanelController.StartSystem();

        _inputs.TurnOn(false);
    }

    public void Restart()
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

            _GameUI.GameUiPause();

            Time.timeScale = 0;
        }
    }

    public void Lose()
    {
        _inputs.TurnOff(false);

        _ballController.StopBalls();

        _boostSystem.StopSystem();

        _gamePanelController.LivesCounter(1, false);

        if (_gamePanelController.LivesCount == 0)
            _GameUI.GameUiGameOver();

        else
            _GameUI.GameUiLose();
    }
    public void WinLevel()
    {
        GameProgressController.Instance.PassLevel();

        _inputs.TurnOff(false);

        _ballController.StopBalls();

        _boostSystem.StopSystem();

        _GameUI.GameUiWin();
    }

    private void SubscribeOnUI()
    {
        _GameUI.OnStart += StartGame;
        _GameUI.OnReStart += Restart;
        _GameUI.OnPause += PauseGame;
    }
    private void OnEnable()
    {
        BlocksSystem.OnAllBlocksDestroyed += WinLevel;

        BallsController.OnBallIsFall += Lose;

        Time.timeScale = 1;
    }
    private void OnDisable()
    {
        _GameUI.OnStart -= StartGame;
        _GameUI.OnReStart -= Restart;
        _GameUI.OnPause -= PauseGame;

        BlocksSystem.OnAllBlocksDestroyed -= WinLevel;

        BallsController.OnBallIsFall -= Lose;
    }
}
