using UnityEngine;

public class SettingsPopUp : UIPopUp
{
    [SerializeField] private LangSwitcher _langSwitcher;

    [SerializeField] private ButtonElement _homeButton;

    public override void InitPopUp()
    {
        _langSwitcher.Init(_langHandler);

        _homeButton.SetDownAction(_controller.HidePop, true);
    }
}
