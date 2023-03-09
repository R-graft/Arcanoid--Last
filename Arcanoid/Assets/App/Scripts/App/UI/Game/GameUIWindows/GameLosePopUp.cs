using UnityEngine;

public class GameLosePopUp : UIPopUp
{
    [SerializeField]
    private ButtonElement _buttonContinue;

    public override void InitPopUp()
    {
        //_buttonContinue.SetUpAction(uiParent.OnReStart, true);
        //_buttonContinue.SetUpAction(HideWindow, true);
    }
}
