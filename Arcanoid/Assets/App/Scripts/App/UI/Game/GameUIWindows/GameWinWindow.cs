using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWinWindow : UIWindow<GameUI>
{
    [SerializeField]
    private Image _levelLogo;

    [SerializeField]
    private Slider _levelProgress;

    [SerializeField]
    private TextMeshProUGUI _levelName;

    [SerializeField]
    private TextMeshProUGUI _energy;

    [SerializeField]
    private PacksData _packsData;

    [SerializeField]
    private ButtonElement _continue;

    public override void InitWindow(GameUI uiParent)
    {
        _continue.SetDownAction(HideWindow, true);

        _continue.SetDownAction(uiParent.OnStart, true);
        _continue.SetDownAction(uiParent.OnReStart, true);
    }

    public override void ShowWindow()
    {
        base.ShowWindow();

        if (!GameProgressController.Instance)
        {
            Debug.Log("Game progress not exist");
            return;
        }

        var pack = GameProgressController.Instance.PacksController.GetCurrentPack();

        _levelLogo.sprite = pack.sprite;

        _levelName.text = pack.title;

        _energy.text = GameProgressController.Instance.EnergyCounter.GetEnergy().ToString();

        ProgressIncrease();
    }

    private void ProgressIncrease()
    {
        Pack currentPack = GameProgressController.Instance.PacksController.GetCurrentPack();

        float currentPogress = (float)currentPack.EndedLevel / (float)currentPack.finishLevel;

        _levelProgress.value = ((float)currentPack.EndedLevel - 1) / (float)currentPack.finishLevel;

        DOTween.To(() => _levelProgress.value, x => _levelProgress.value = x, currentPogress, 1);
    }
}
