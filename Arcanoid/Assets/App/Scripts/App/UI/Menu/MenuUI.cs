using UnityEditor;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private UIWindow<MenuUI> _settingsWindow;

    [SerializeField]
    private UIWindow<MenuUI> _startWindow;

    public void Start()
    {
        _settingsWindow.InitWindow(this);

        _startWindow.InitWindow(this);

        _startWindow.ShowWindow();
    }

    public void StartGame()
    {
        if (GameProgressController.Instance.GameAccess)
        {
            if (PlayerPrefs.HasKey("FirstIn"))
            {
                ScenesManager.Instance.LoadScene(SCENELIST.PackScene);
            }
            else
            {
                PlayerPrefs.SetInt("FirstIn", default);

                ScenesManager.Instance.LoadScene(SCENELIST.GameScene);
            }
        }

        return;
    }

    public void ShowSettingsWindow() => _settingsWindow.ShowWindow();

    public void ExitApplication()
    {
#if UNITY_EDITOR
        PlayerPrefs.DeleteKey("FirstIn");
        EditorApplication.isPlaying = false;
#endif
#if PLATFORM_ANDROID
        PlayerPrefs.DeleteKey("FirstIn");
        Application.Quit();
#endif
    }
}

