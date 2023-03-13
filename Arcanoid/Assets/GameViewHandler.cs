using UnityEngine;

public class GameViewHandler : MonoBehaviour, IGameHandler
{
    [SerializeField] private GamePanelController _gamePanelController;

    private GameUIWindow _GameUI;

    private LevelController _levelController;

    public void InitLevelView(GameUIWindow gameUI)
    {
        _GameUI = gameUI;
    }

    public void StartGame()
    {
        //_gamePanelController.StartSystem();
    }

    public void PauseGame()
    {
        _GameUI.GameUiPause();
    }

    public void RestartGame()
    {
    }

    public void WinGame()
    {
        _GameUI.GameUiWin();
    }

    public void LoseGame()
    {
        _GameUI.GameUiGameOver();

        _gamePanelController.LivesCounter(1, false);
    }

    public void InitController(LevelController controller)
    {
        _levelController = controller;
    }
}
