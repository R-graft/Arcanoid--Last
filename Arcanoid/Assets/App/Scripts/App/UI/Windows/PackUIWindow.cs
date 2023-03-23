using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PackUIWindow : UIWindow
{
    [SerializeField] private ButtonElement _homeButton;

    [SerializeField] private PackViewManager _viewManager;

    private EnergyCounter _energy;
    public override void InitWindow()
    {
        _energy = ProjectContext.Instance.GetService<EnergyCounter>();

        var (current, max) = _energy.GetCurrentEnergy();

        _viewManager.Init();

        _homeButton.SetDownAction(() => _viewManager.ExitAnimation(), true);

        _homeButton.SetDownAction(() => ScenesManager.Instance.LoadScene(SCENELIST.StartScene), true);
    }
}
