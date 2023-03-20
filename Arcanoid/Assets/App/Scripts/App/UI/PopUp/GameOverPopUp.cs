using UnityEngine;

public class GameOverPopUp : UIPopUp
{
    [SerializeField] private ButtonElement _purchaseContinue;

    [SerializeField] private ButtonElement _restartButton;

    private LevelController _levelController;

    private EnergyCounter _energy;

    private GamePanelController _gamePanel;

    private const int EnergyForContinue = 7;

    public override void InitPopUp()
    {
        _energy = ProjectContext.Instance.GetService<EnergyCounter>();

        _restartButton.SetDownAction(()=> ProjectContext.Instance.GetService<LevelController>().Restart(), true);

        _restartButton.SetDownAction(_controller.HidePop, true);

        _purchaseContinue.SetDownAction(() => PurchaseLife(), true);

        _purchaseContinue.SetDownAction(_controller.HidePop, true);
    }

    public override void Show()
    {
        base.Show();

        _purchaseContinue.gameObject.SetActive(_energy.GetCurrentEnergy().current >= EnergyForContinue);
    }


    public void PurchaseLife()
    {
        _gamePanel ??= LevelContext.Instance.GetSystem<GamePanelController>();

        _energy.DecreaseEnergy(EnergyForContinue);

        _gamePanel.AddLife();
    }
}
