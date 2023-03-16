using UnityEngine;
public class GameMenuPopUp : UIPopUp
{
    [SerializeField] private ButtonElement _restartButton;

    [SerializeField] private ButtonElement _backButton;

    [SerializeField] private ButtonElement _continueButton;

    public override void InitPopUp()
    {
        _restartButton.SetDownAction(()=> ProjectContext.Instance.GetService<LevelController>().Restart(), true);
        _restartButton.SetDownAction(_controller.HidePop, true);

        _backButton.SetDownAction(()=> Time.timeScale = 1, true);
        _backButton.SetDownAction(()=> ScenesManager.Instance.LoadScene(SCENELIST.PackScene), true);

        _continueButton.SetUpAction(_controller.HidePop, true);
    }
}
