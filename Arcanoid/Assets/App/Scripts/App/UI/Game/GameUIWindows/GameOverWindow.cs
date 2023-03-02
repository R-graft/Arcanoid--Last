using UnityEngine;

public class GameOverWindow : UIWindow<GameUI>
{
    [SerializeField] private ButtonElement _continueButton;

    [SerializeField] private ButtonElement _exitButton;

    private const int EnergyForContinue = 5;

    private const int ExtraLives = 1;

    public override void InitWindow(GameUI uiParent)
    {
        _continueButton.SetDownAction(OnButtonContinueWihEnergy, true);
        _continueButton.SetDownAction(uiParent.OnReStart, true);

        _continueButton.SetDownAction(HideWindow, true);

        _exitButton.SetDownAction(uiParent.OnSceneLoad, true);
    }

    public override void ShowWindow()
    {
        base.ShowWindow();

        _continueButton.gameObject.SetActive(GameProgressController.Instance.EnergyCounter.GetEnergy() >= EnergyForContinue);
    }

    public void OnButtonContinueWihEnergy()
    {
        GameProgressController.Instance.SetEnergy(EnergyForContinue, false);

        BonusEvents.OnSetLives.Invoke(ExtraLives, true);
    }
}
