using System;
using UnityEngine;

public class GameUIWindow : UIWindow
{
    [SerializeField] private ButtonElement _pauseButton;

    private ScenesManager _scenesManager;

    public override void InitWindow()
    {
        _scenesManager = ProjectContext.Instance.GetService<ScenesManager>();

        _pauseButton.SetDownAction(()=> GameUiPause(), true);
    }

    public void GameUiWin()
    {
        _popUpHandler.ShowPop("win");
    }

    public void GameUiPause()
    {
        _popUpHandler.ShowPop("pause");
    }
    public void GameUiGameOver()
    {
        _popUpHandler.ShowPop("lose");
    }

    
}
