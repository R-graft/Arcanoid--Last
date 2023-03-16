using UnityEngine;

public class GameOverPopUp : UIPopUp
{
    [SerializeField] private ButtonElement _purchaseContinue;

    [SerializeField] private ButtonElement _continueButton;

    private LevelController _levelController;

    private const int EnergyForContinue = 5;

    private const int ExtraLives = 1;

    public override void InitPopUp()
    {
        _continueButton.SetDownAction(()=> ProjectContext.Instance.GetService<LevelController>().Restart(), true);

        _continueButton.SetDownAction(_controller.HidePop, true);
    }

    //public override void ShowWindow()
    //{
    //    base.ShowWindow();

    //    _continueButton.gameObject.SetActive(GameProgressController.Instance.EnergyCounter.GetEnergy() >= EnergyForContinue);
    //}

    //public void OnButtonContinueWihEnergy()
    //{
    //    // GameProgressController.Instance.SetEnergy(EnergyForContinue, false);

    //    BonusEvents.OnSetLives.Invoke(ExtraLives, true);
    //}
}
