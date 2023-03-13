using System;
using System.Collections.Generic;
using UnityEngine;

public class LangHandler : IService
{
    private WordList _translatesData;

    public Dictionary<string, string> TranslatesDictionary { get; private set; }

    public List<string> AvaliableLangs { get; private set; }

    public string CurrentLang { get; private set; }

    private const string LangKey = "CurrentLangKey";

    private const string DefaultLang = "eng";

    public Action<Dictionary<string, string>> OnChangeLang;

    public void Init()
    {
        LoadLang();

        GetTranslatesData();

        SetLangDict();

        SetAvaliableLangs();
    }

    private void LoadLang()
    {
        if (!PlayerPrefs.HasKey(LangKey) || CurrentLang == "")
        {
            PlayerPrefs.SetString(LangKey, DefaultLang);
        }

        CurrentLang = PlayerPrefs.GetString(LangKey);

        SaveLang(CurrentLang);
    }

    private void SaveLang(string lang) 
    {
        PlayerPrefs.SetString(LangKey, lang);
    }

    public string GetPhrase(string key)
    {
        if (TranslatesDictionary == null)
        {
            SetLangDict();
        }

        if (!TranslatesDictionary.TryGetValue(key, out string phrase))
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
                CurrentLang = langName;

                SetLangDict();

                OnChangeLang?.Invoke(TranslatesDictionary);
            }

            SaveLang(langName);
        }
    }

    private void SetLangDict()
    {
        TranslatesDictionary = new Dictionary<string, string>();

        foreach (var word in _translatesData.words)
        {
            foreach (var phrase in word.phrases)
            {
                if (phrase.langName == CurrentLang)
                {
                    TranslatesDictionary.Add(word.key, phrase.phrase);
                }
            }
        }
    }

    private void SetAvaliableLangs()
    {
        AvaliableLangs = new List<string>();

        foreach (var lang in _translatesData.languages)
        {
            AvaliableLangs.Add(lang);
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




