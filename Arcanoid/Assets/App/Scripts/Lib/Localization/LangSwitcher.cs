using UnityEngine;
using TMPro;
using System;

public class LangSwitcher : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown _switcher;

    private int _langId;

    public static Action<int> OnLangSwitch;

    public void SetLanguage(TMP_Dropdown drop)
    {
        _langId = drop.value;

        OnLangSwitch.Invoke(_langId);
    }

    public void Init()
    {
        _langId = PlayerPrefs.GetInt("CurrentLangIndex");

        _switcher.value = _langId;
    }
}