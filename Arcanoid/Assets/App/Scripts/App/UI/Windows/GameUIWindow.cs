using UnityEngine;

public class GameUIWindow : UIWindow
{
    [SerializeField] private ButtonElement _pauseButton;

    private Inputs _inputs;
    public override void InitWindow()
    {
        _pauseButton.SetDownAction(() => GameUiPause(), true);

        _inputs ??= ProjectContext.Instance.GetService<Inputs>();
    }

    public void GameUiWin()
    {
        _inputs.TurnOff(true);

        Invoke(nameof(WinUnHold), 1);
    }

    public void GameUiPause()
    {
        _popUpHandler.ShowPop("gamemenu");
    }
    public void GameUiGameOver()
    {
        _popUpHandler.ShowPop("lose");
    }

    private void WinUnHold()
    {
        _popUpHandler.ShowPop("win");

        _inputs.TurnOn(true);
    }
}
