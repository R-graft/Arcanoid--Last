using UnityEngine;

public class GameOverPopUp : UIPopUp
{
    [SerializeField] private ButtonElement _purchaseContinue;

    [SerializeField] private ButtonElement _restartButton;

    [SerializeField] private ButtonElement _back;

    [SerializeField] private EnergyBarCounter _bar;

    private LevelController _levelController;

    private EnergyCounter _energy;

    private GamePanelController _gamePanel;

    private AnimateHandler _animHandler;

    private const int EnergyForContinue = 7;

    private const int EnergyForRestart = 3;

    public override void InitPopUp()
    {
        _energy = ProjectContext.Instance.GetService<EnergyCounter>();

        _restartButton.SetDownAction(()=> SetRestart(), true);

        _purchaseContinue.SetDownAction(() => PurchaseLife(), true);

        _back.SetDownAction(() => Time.timeScale = 1, true);
        _back.SetDownAction(()=> ScenesManager.Instance.LoadScene(1), true);
    }

    public override void Show()
    {
        Time.timeScale = 0;

        base.Show();
    }

    public override void Hide()
    {
        Time.timeScale = 1;

        base.Hide();
    }

    public void SetRestart()
    {
        if (_energy.GetCurrentEnergy().current >= EnergyForRestart)
        {
            ProjectContext.Instance.GetService<LevelController>().Restart();

            _controller.HidePop();
        }
        else
        {
            _bar.DisableEffect();
        }
    }
    public void PurchaseLife()
    {
        if (_energy.GetCurrentEnergy().current >= EnergyForContinue)
        {
            _gamePanel ??= LevelContext.Instance.GetSystem<GamePanelController>();

            _gamePanel.AddLife();

            _energy.DecreaseEnergy(EnergyForContinue);

            _bar.DecreaseEffect(_controller.HidePop);
        }
        else
        {
            _bar.DisableEffect();
        }
    }
}
