using UnityEngine;

public class GameLoseWindow : UIWindow<GameUI>
{
    [SerializeField]
    private ButtonElement _buttonContinue;

    public override void InitWindow(GameUI uiParent)
    {
        _buttonContinue.SetUpAction(uiParent.OnReStart, true);
        _buttonContinue.SetUpAction(HideWindow, true);
    }
}
