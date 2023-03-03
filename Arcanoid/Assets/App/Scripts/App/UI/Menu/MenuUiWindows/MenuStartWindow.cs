using DG.Tweening;
using TMPro;
using UnityEngine;

public class MenuStartWindow : UIWindow<MenuUI>
{
    [SerializeField] private ButtonElement _buttonSettingsGame;

    [SerializeField] private ButtonElement _buttonStartGame;

    [SerializeField] private ButtonElement _buttonExitGame;

    public override void InitWindow(MenuUI UIParent)
    {
        _buttonSettingsGame.SetDownAction(UIParent.ShowSettingsWindow, true);

        _buttonStartGame.SetDownAction(UIParent.StartGame, true);

        _buttonExitGame.SetDownAction(UIParent.ExitApplication, true);
    }

    public override void InAnimation()
    {

    }
}
