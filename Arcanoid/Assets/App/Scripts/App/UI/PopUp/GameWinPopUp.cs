using TMPro;
using UnityEngine;

public class GameWinPopUp : UIPopUp
{
    [SerializeField] private ButtonElement _continue;

    [SerializeField] private WinPopUpAnimator _panelAnimator;

    private LevelController _levelcontroller;

    private PackDataController _packsData;

    [HideInInspector] public Sprite oldSprite;
    [HideInInspector] public Sprite newSprite;

    [HideInInspector] public int oldLevel;
    [HideInInspector] public int newLevel;

    [HideInInspector] public int oldMaxLevel;
    [HideInInspector] public int newMaxLevel;

    [HideInInspector] public string oldName;
    [HideInInspector] public string newName;
    public override void InitPopUp()
    {
        _packsData ??= ProjectContext.Instance.GetService<PackDataController>();

        _levelcontroller ??= ProjectContext.Instance.GetService<LevelController>();

        _levelcontroller.OnLevelIsLoaded += GetDataOnLoad;

        _continue.SetDownAction(() => _levelcontroller.Restart(), true);

        _continue.SetDownAction(_controller.HidePop, true);
    }

    public override void Show()
    {
        _enterAnimHold = 1;

        base.Show();

        GetDataOnWin();

        ProgressIncrease();
    }

    public override void Hide()
    {
        _panelAnimator.StopAnimate();

        base.Hide();
    }
    private void GetDataOnLoad()
    {
        oldLevel = _packsData.GetCurrentPackLevel();

        oldMaxLevel = _packsData.GetCurrentPackLastLevel();

        oldName = _packsData.GetCurrentPack().title;

        oldSprite = _packsData.GetCurrentPack().sprite;
    }

    private void GetDataOnWin()
    {
        newLevel = _packsData.GetCurrentPackLevel();

        newMaxLevel = _packsData.GetCurrentPackLastLevel();

        newName = _packsData.GetCurrentPack().title;

        newSprite = _packsData.GetCurrentPack().sprite;
    }

    private void ProgressIncrease()
    {
        _panelAnimator.gameObject.SetActive(true);

        _panelAnimator.AnimateProgress(this);
    }
}