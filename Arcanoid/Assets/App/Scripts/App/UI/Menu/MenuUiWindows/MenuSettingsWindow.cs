using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettingsWindow : UIWindow<MenuUI>
{
    [SerializeField]
    private LangSwitcher _langSwitcher;

    [SerializeField]
    private ButtonElement _homeButton;

    public override void InitWindow(MenuUI uiParent)
    {
        _langSwitcher.Init();

        _homeButton.SetDownAction(HideWindow, true);
    }

    public override void InAnimation()
    {
        gameObject.SetActive(true);

        transform.position = new Vector2(-10, transform.position.y);

        DOTween.Sequence().Append(transform.DOMoveX(0, 0.3f));
    }

    public override void OutAnimation() =>
        DOTween.Sequence().Append(transform.DOMoveX(10, 0.2f).
        OnComplete(() => transform.position = new Vector2(-10, transform.position.y))).
        AppendCallback(() => gameObject.SetActive(false));
}
