using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class LangHandler : IService
{
    private WordList _translatesData;

    private Dictionary<string, string> _translatesDictionary;

    public string CurrentLang { get; private set; }

    public List<string> AvaliableLangs { get; private set; }

    private const string DefaultLang = "eng";

    private const string LangKey = "CurrentLangKey";

    public Action<string> OnChangeLang;

    public LangHandler()
    {
        Init();
    }
    public void Init()
    {
        LoadLang();

        GetTranslatesData();

        _translatesDictionary = new Dictionary<string, string>();

        SetLangDict(_translatesDictionary);

        AvaliableLangs = new List<string>();

        foreach (var lang in _translatesData.languages)
        {
            AvaliableLangs.Add(lang);
        }
    }

    private void LoadLang()
    {
        if (!PlayerPrefs.HasKey(LangKey))
        {
            PlayerPrefs.SetString(LangKey, DefaultLang);
        }

        CurrentLang = PlayerPrefs.GetString(LangKey);
    }

    private void SaveLang(string lang) 
    {
        PlayerPrefs.SetString(LangKey, lang);
    }

    public string GetPhrase(string key)
    {
        if (_translatesDictionary == null)
        {
            _translatesDictionary = new Dictionary<string, string>();

            SetLangDict(_translatesDictionary);
        }

        if (!_translatesDictionary.TryGetValue(key, out string phrase))
        {
            Debug.Log($"Translate key {key} not present in translate dictionary");
        }

        return phrase;
    }

    public void SetLang(string langName)
    {
        if (langName != CurrentLang)
        {
            if (_translatesData.languages.Contains(langName))
            {
                _translatesDictionary = new Dictionary<string, string>();

                SetLangDict(_translatesDictionary);
            }

            SaveLang(langName);
        }
    }

    private void SetLangDict(Dictionary<string, string> translateDict)
    {
        foreach (var word in _translatesData.words)
        {
            foreach (var phrase in word.phrases)
            {
                if (phrase.langName == CurrentLang)
                {
                    translateDict.Add(word.key, phrase.phrase);
                }
            }
        }
    }

    private void GetTranslatesData()
    {
        if (_translatesData == null)
        {
            _translatesData = Resources.Load<WordList>("Data/Localization/WordList");
        }
    }
}




