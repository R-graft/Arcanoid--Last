using UnityEngine;
public class GameMenuPopUp : UIPopUp
{
    [SerializeField] private ButtonElement _restartButton;

    [SerializeField] private ButtonElement _backButton;

    [SerializeField] private ButtonElement _continueButton;

    [SerializeField] private EnergyCounter _energy;

    public override void InitPopUp()
    {
        base.InitPopUp();

        _energy ??= ProjectContext.Instance.GetService<EnergyCounter>();

        _restartButton.SetUpAction(()=> RestartAccess(), true);

        _backButton.SetDownAction(()=> Time.timeScale = 1, true);
        _backButton.SetDownAction(()=> ScenesManager.Instance.LoadScene(SCENELIST.PackScene), true);

        _continueButton.SetDownAction(_controller.HidePop, true);
    }

    private void RestartAccess()
    {
        if (_energy.GetGameAsses())
        {
            ProjectContext.Instance.GetService<LevelController>().Restart();

            _controller.HidePop();
        }
    }
}
