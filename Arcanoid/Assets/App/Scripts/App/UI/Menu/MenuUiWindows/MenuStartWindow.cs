using DG.Tweening;
using TMPro;
using UnityEngine;

public class MenuStartWindow : UIWindow<MenuUI>
{
    [SerializeField]
    private ButtonElement _buttonSettingsGame;

    [SerializeField]
    private ButtonElement _buttonStartGame;

    [SerializeField]
    private ButtonElement _buttonExitGame;

    [SerializeField]
    private TextMeshProUGUI _energyValue;

    [SerializeField]
    private TextMeshProUGUI _logo;

    public override void InitWindow(MenuUI UIParent)
    {
        _buttonSettingsGame.SetDownAction(UIParent.ShowSettingsWindow, true);

        _buttonStartGame.SetDownAction(UIParent.StartGame, true);

        _buttonExitGame.SetDownAction(UIParent.ExitApplication, true);

        _energyValue.text = GameProgressController.Instance.EnergyCounter.GetEnergy().ToString();
    }

    public override void InAnimation()
    {

    }
}
