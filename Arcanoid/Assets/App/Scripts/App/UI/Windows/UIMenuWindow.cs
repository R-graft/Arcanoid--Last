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
        if (!PlayerPrefs.HasKey("FirstIn") && _energy.GetGameAsses())
        {
            PlayerPrefs.SetInt("FirstIn", default);

            ScenesManager.Instance.LoadScene(2);
        }

        else
        {
            ScenesManager.Instance.LoadScene(1);
        }
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
