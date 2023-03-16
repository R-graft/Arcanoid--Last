using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWinPopUp : UIPopUp
{
    [SerializeField] private Image _levelLogo;

    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _levelsInPack;

    [SerializeField] private TextMeshProUGUI _levelName;

    [SerializeField] private TextMeshProUGUI _energyValue;
    [SerializeField] private TextMeshProUGUI _maxEnergyValue;

    [SerializeField] private Slider _energySlide;

    [SerializeField] private ButtonElement _continue;

    private PackDataController _packsData;

    private EnergyCounter _energy;

    private int _oldLevel;
    private int _newLevel;

    public override void InitPopUp()
    {
        _continue.SetDownAction(() => ProjectContext.Instance.GetService<LevelController>().Restart(), true);

        _continue.SetDownAction(_controller.HidePop, true);
    }

    public override void Show()
    {
        base.Show();

        _packsData = ProjectContext.Instance.GetService<PackDataController>();

        _energy = ProjectContext.Instance.GetService<EnergyCounter>();

        _level.text = _packsData.GetCurrentPackLevel().ToString();

        _levelsInPack.text = _packsData.GetCurrentPackLastLevel().ToString();

        _levelLogo.sprite = _packsData.GetCurrentPack().sprite;

        _levelName.text = _packsData.GetCurrentPack().title.ToString();

        var (current, max) = _energy.GetCurrentEnergy();

        _energyValue.text = current.ToString();

        _maxEnergyValue.text = max.ToString();

        _energySlide.value = (float)current/ (float)max;

        //ProgressIncrease();
    }

    private void ProgressIncrease()
    {
        //Pack currentPack = GameProgressController.Instance.PacksController.GetCurrentPack();

        //float currentPogress = (float)currentPack.EndedLevel / (float)currentPack.finishLevel;

        //_levelProgress.value = ((float)currentPack.EndedLevel - 1) / (float)currentPack.finishLevel;

       // DOTween.To(() => _levelProgress.value, x => _levelProgress.value = x, currentPogress, 1);
    }
}
