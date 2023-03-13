using UnityEngine;

public class UIPackWindow : UIWindow
{
    [SerializeField]
    private ButtonElement _homeButton;

    [SerializeField]
    private PackViewManager _viewManager;

    public override void InitWindow()
    {
        _viewManager.Init();

        _homeButton.SetDownAction(() => ScenesManager.Instance.LoadScene(SCENELIST.StartScene), true);
    }
}
