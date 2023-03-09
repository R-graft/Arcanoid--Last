using UnityEditor;
using UnityEngine;

public class MenuStartWindow : MonoBehaviour
{
    [SerializeField] private ButtonElement _buttonSettingsGame;

    [SerializeField] private ButtonElement _buttonStartGame;

    [SerializeField] private ButtonElement _buttonExitGame;

    private UIPopUpController _popUpController;

    public void Start()
    {
        _popUpController = UIPopUpController.Instance;

        _buttonSettingsGame.SetDownAction(()=> _popUpController.ShowPop("settings"), true);

        _buttonStartGame.SetDownAction(()=> StartGame(), true);

        _buttonExitGame.SetDownAction(()=> ExitApplication(), true);
    }

    private void StartGame()
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
