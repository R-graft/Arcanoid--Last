using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelView :MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentLevel;
    [SerializeField] private TextMeshProUGUI _maxPackLevel;

    [SerializeField] private Image _levelLogo;

    [SerializeField] private TextMeshProUGUI _levelProgressCounter;

    [SerializeField] private Image[] _livesPanel;

    [SerializeField] private Sprite _activeLife;
    [SerializeField] private Sprite _deActiveLife;

    private PackDataController _packsData;

    public int _currentLife;

    public void Init(PackDataController packs)
    {
        _packsData = packs;
    }
    
    public void RefreshPanel()
    {
        _currentLevel.text = _packsData.GetCurrentPackLevel().ToString();

        _maxPackLevel.text = _packsData.GetCurrentPackLastLevel().ToString();

        _levelLogo.sprite = _packsData.GetCurrentPack().sprite;

        _levelProgressCounter.text = "0";
    }

    public void SetStartLives(int count)
    {
        _currentLife = 0;

        for (int i = 0; i < count; i++)
        {
            AddLife();
        }
    }

    public void RemoveLife()
    {
        _currentLife--;

        _currentLife = _currentLife < 0 ? 0: _currentLife;

        if (_currentLife < _livesPanel.Length)
        {
            _livesPanel[_currentLife].sprite = _deActiveLife;
        }
    }

    public void AddLife()
    {
        if ( _currentLife < _livesPanel.Length)
        {
            _livesPanel[_currentLife].sprite = _activeLife;
        }

        _currentLife++;
    }

    public void SetProgress(int value)
    {
        _levelProgressCounter.text = value.ToString();
    }
    public void AddProgress(float value)
    {
        float currentProgrress = float.Parse(_levelProgressCounter.text);

        currentProgrress += value;

        _levelProgressCounter.text = currentProgrress.ToString();
    }
}
