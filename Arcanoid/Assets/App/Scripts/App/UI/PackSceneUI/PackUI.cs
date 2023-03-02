using UnityEngine;

public class PackUI : MonoBehaviour
{
    [SerializeField]
    private ButtonElement _homeButton;

    [SerializeField]
    private PackViewManager _viewManager;

    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        _viewManager.Init();

        _homeButton.SetDownAction(()=> ScenesManager.Instance.LoadScene(SCENELIST.StartScene), true);
    }
}
