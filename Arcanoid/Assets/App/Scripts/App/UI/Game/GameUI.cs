using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private UIWindow<GameUI> _win;
    [SerializeField]
    private UIWindow<GameUI> _lose;
    [SerializeField]
    private UIWindow<GameUI> _pause;
    [SerializeField]
    private UIWindow<GameUI> _gameOver;

    [SerializeField]
    private ButtonElement _pauseButton;

    [SerializeField]
    private List<Sprite> _gameBackgroundsList;

    [SerializeField]
    private Image _backGround;

    public Action OnStart;

    public Action OnReStart;

    public Action OnPause;

    public Action OnSceneLoad = delegate { ScenesManager.Instance.LoadScene(SCENELIST.PackScene); } ;

    public void Init()
    {
        _win.InitWindow(this);
        _lose.InitWindow(this);
        _gameOver.InitWindow(this);
        _pause.InitWindow(this);

        _pauseButton.SetDownAction(OnPause, true);

        _backGround.sprite = _gameBackgroundsList[GameProgressController.Instance.PacksController.GetCurrentPack().packIndex];
    }

    public void GameUiWin()
    {
        _win.ShowWindow();
    }
    public void GameUiLose()
    {
        _lose.ShowWindow();
    }
    public void GameUiPause()
    {
        _pause.ShowWindow();
    }
    public void GameUiGameOver()
    {
        _gameOver.ShowWindow();
    }
}
