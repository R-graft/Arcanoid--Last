using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class LangSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _switcher;

    private LangHandler _langHandler;

    private List<string> _avaliableLangs;

    private Dictionary<int, string> _langsValues;

    private const string CurrentIndexKey = "CurrentIndexKey";

    private int _currentIndex;

    public void Init(LangHandler langHandler)
    {
        _langHandler = langHandler;

        _avaliableLangs = _langHandler.Langs.Keys.ToList();

        SetDropDownValues();

        GetCurerntIndex();

        _switcher.value = _currentIndex;
    }

    public void SetLang(TMP_Dropdown drop)
    {
        _currentIndex = drop.value;

        _langHandler.SwitchLang(_langsValues[_currentIndex]);

        _switcher.value = _currentIndex;

        SetCurrentIndex();
    }

    private void SetDropDownValues()
    {
        for (int i = 0; i < _avaliableLangs.Count; i++)
        {
            _switcher.options[i].text = _avaliableLangs[i];
        }

        if (_langsValues == null)
        {
            _langsValues = new Dictionary<int, string>();

            for (int i = 0; i < _avaliableLangs.Count; i++)
            {
                _langsValues.Add(i, _avaliableLangs[i]);
            }
        }
    }

    private void SetCurrentIndex()
    {
        PlayerPrefs.SetInt(CurrentIndexKey, _currentIndex);
    }

    private void GetCurerntIndex()
    {
        _currentIndex = PlayerPrefs.GetInt(CurrentIndexKey);
    }
}