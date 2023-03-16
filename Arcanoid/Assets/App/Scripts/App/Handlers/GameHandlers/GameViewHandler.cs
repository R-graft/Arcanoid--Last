using System.Collections.Generic;
using UnityEngine;

public class GameViewHandler : MonoBehaviour, IGameHandler
{
    [SerializeField] private GamePanelController _gamePanelController;

    [SerializeField] private List<GameSystem> _viewSystemsList;

    private GameUIWindow _GameUI;

    private LevelController _levelController;

    public void InitLevelView(GameUIWindow gameUI)
    {
        _GameUI = gameUI;

        _gamePanelController.Init();
    }

    public void SetHandler(LevelController controller)
    {
        _levelController = controller;

        _gamePanelController.controller = controller;
    }

    public void SetStart()
    {
        
    }
    public void SetRestart()
    {
        _gamePanelController.ReStart();
    }
    public void SetPause()
    {
        _GameUI.GameUiPause();
    }

    public void SetOver()
    {
        _GameUI.GameUiGameOver();
    }

    public void SetWin()
    {
        _GameUI.GameUiWin();

        _gamePanelController.Win();
    }

    public void SetLose()
    {
        _gamePanelController.Lose();
    }
}
