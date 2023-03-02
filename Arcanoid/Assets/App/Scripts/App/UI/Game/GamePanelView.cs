using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelView :MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _currentLevel;

    [SerializeField]
    private Image _levelLogo;

    [SerializeField]
    private Image _levelProgressFill;

    [SerializeField]
    private TextMeshProUGUI _packName;

    public void Init(PacksData packsData)
    {
        if (GameProgressController.Instance)
        {
            var progress = GameProgressController.Instance;

            _currentLevel.text = progress.PacksController.GetCurrentPackLevel().ToString();

            _packName.text = progress.PacksController.GetCurrentPack().title;

            _levelLogo.sprite = progress.PacksController.GetCurrentPack().sprite;

            _levelProgressFill.fillAmount = 0;
        }

        else
            Debug.Log("GameProgress not exist");
    }
    
    public void SetProgress(float value)
    {
        _levelProgressFill.fillAmount += value;
    }
}
