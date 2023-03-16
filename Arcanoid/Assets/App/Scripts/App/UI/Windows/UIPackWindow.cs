using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPackWindow : UIWindow
{
    [SerializeField] private ButtonElement _homeButton;

    [SerializeField] private PackViewManager _viewManager;

    [SerializeField] private TextMeshProUGUI _energyValue;
    [SerializeField] private TextMeshProUGUI _maxEnergyValue;

    [SerializeField] private Slider _energySlide;

    private EnergyCounter _energy;
    public override void InitWindow()
    {
        _energy = ProjectContext.Instance.GetService<EnergyCounter>();

        var (current, max) = _energy.GetCurrentEnergy();

        _energyValue.text = current.ToString();

        _maxEnergyValue.text = max.ToString();

        _energySlide.value = (float)current / (float)max;

        _viewManager.Init();

        _homeButton.SetDownAction(() => ScenesManager.Instance.LoadScene(SCENELIST.StartScene), true);
    }
}
