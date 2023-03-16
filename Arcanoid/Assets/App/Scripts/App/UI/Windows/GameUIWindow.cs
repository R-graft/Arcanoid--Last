using UnityEngine;

public class GameUIWindow : UIWindow
{
    [SerializeField] private ButtonElement _pauseButton;
    public override void InitWindow()
    {
        _pauseButton.SetDownAction(() => GameUiPause(), true);
    }

    public void GameUiWin()
    {
        _popUpHandler.ShowPop("win");
    }

    public void GameUiPause()
    {
        _popUpHandler.ShowPop("gamemenu");
    }
    public void GameUiGameOver()
    {
        _popUpHandler.ShowPop("lose");
    }

    public void SetPause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        else
        {
            Time.timeScale = 0;
        }
    }
}
