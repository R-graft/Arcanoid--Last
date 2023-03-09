using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class LangSwitcher : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _switcher;

    private LangHandler _langHandler;

    private int _langId;

    private List<string> _avaliableLangs;

    private string _currentLang;

    public static Action<int> OnLangSwitch;

    private void Awake()
    {
        Init();
    }

    public void SetLanguage(TMP_Dropdown drop)
    {
        _langId = drop.value;

        _langHandler.SetLang(_currentLang);
    }

    public void Init()
    {
        _langHandler = MainServiceLocator.Instance.GetService<LangHandler>();

        _currentLang = _langHandler.CurrentLang;

        _avaliableLangs = _langHandler.AvaliableLangs;

        _switcher.value = _langId;

        SetDropDownValues(_switcher);
    }

    private void SetDropDownValues(TMP_Dropdown drop)
    {
        for (int i = 0; i < _avaliableLangs.Count; i++)
        {
            drop.options[i].text = _avaliableLangs[i];
        }
     
    }
}