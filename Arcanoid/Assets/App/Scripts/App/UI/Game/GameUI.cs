using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UIPopUp
{
    [SerializeField] private UIPopUp _win;
    [SerializeField] private UIPopUp _pause;
    [SerializeField] private UIPopUp _gameOver;

    [SerializeField] private ButtonElement _pauseButton;

    [SerializeField] private Image _backGround;

    public Action OnStart;

    public Action OnReStart;

    public Action OnPause;

    public Action OnSceneLoad = delegate { ScenesManager.Instance.LoadScene(SCENELIST.PackScene); } ;

    public void Init()
    {
        //_win.InitWindow(this);
        //_gameOver.InitWindow(this);
        //_pause.InitWindow(this);

        //_pauseButton.SetDownAction(OnPause, true);
    }

    public void GameUiWin()
    {
        //_win.ShowWindow();
    }

    public void GameUiPause()
    {
        //_pause.ShowWindow();
    }
    public void GameUiGameOver()
    {
        //_gameOver.ShowWindow();
    }

    public override void InitPopUp()
    {
        throw new NotImplementedException();
    }
}
