using UnityEditor;
using UnityEngine;

public class UIMenuWindow : UIWindow
{
    [SerializeField] private ButtonElement _buttonSettingsGame;

    [SerializeField] private ButtonElement _buttonStartGame;

    [SerializeField] private ButtonElement _buttonExitGame;

    private EnergyCounter _energy;

    public override void InitWindow()
    {
        _energy = ProjectContext.Instance.GetService<EnergyCounter>();

        _buttonSettingsGame.SetDownAction(() => _popUpHandler.ShowPop("settings"), true);

        _buttonStartGame.SetDownAction(() => StartGame(), true);

        _buttonExitGame.SetDownAction(() => ExitApplication(), true);
    }

    private void StartGame()
    {
        if (_energy.GetGameAsses())
        {
            if (PlayerPrefs.HasKey("FirstIn"))
            {
                ScenesManager.Instance.LoadScene(1);
            }
            else
            {
                PlayerPrefs.SetInt("FirstIn", default);

                ScenesManager.Instance.LoadScene(2);
            }
        }

        return;
    }

    private void ExitApplication()
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
