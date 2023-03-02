using DG.Tweening;
using UnityEngine;
public class GamePauseWindow : UIWindow<GameUI>
{
    [SerializeField]
    private ButtonElement _exitButton;

    [SerializeField]
    private ButtonElement _continueButton;

    public override void InitWindow(GameUI uiParent)
    {
        _exitButton.SetUpAction(uiParent.OnPause, true);

        _exitButton.SetUpAction(uiParent.OnSceneLoad, true);

        _continueButton.SetUpAction(uiParent.OnPause, true); 

        _continueButton.SetUpAction(HideWindow, true);
    }
    public override void InAnimation()
    {
        gameObject.SetActive(true);

        DOTween.Sequence().Append(transform.DOMoveY(8, 0.1f)).
            Append(transform.DOMoveY(10, 0.1f));
    }
    public override void OutAnimation()
    {
        base.OutAnimation();
    }
}
