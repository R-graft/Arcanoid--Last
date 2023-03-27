using UnityEngine;

public class GameUIWindow : UIWindow
{
    [SerializeField] private ButtonElement _pauseButton;

    [SerializeField] private ButtonElement _passLevel;

    private Inputs _inputs;
    public override void InitWindow()
    {
        _pauseButton.SetDownAction(() => GameUiPause(), true);

        _inputs ??= ProjectContext.Instance.GetService<Inputs>();

        _passLevel.SetDownAction(() => FastWin(), true);
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

    private void FastWin()
    {
        var blocks = LevelContext.Instance.GetSystem<BlocksSystem>();

        var damage = LevelContext.Instance.GetSystem<BlocksDamageHandler>();

        var blockList = blocks.GetBlocksList();

        while (blockList.Count > 0)
        {
            damage.SetDestroy(blockList[0].GetComponent<IDamageable>());
        }
    }
}
