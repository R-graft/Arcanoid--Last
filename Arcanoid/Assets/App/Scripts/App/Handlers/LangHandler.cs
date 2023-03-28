using System;
using System.Collections.Generic;
using UnityEngine;

public class LangHandler : IService
{
    public Dictionary<string, Lang> Langs { get; private set; }

    public Dictionary<string, string> CurrentLangDict;
    public string CurrentLangId { get; private set; }

    private const string LangsPath = "langs";

    private const string LangKey = "CurrentLangKey";

    private const string DefaultLang = "eng";

    public Action OnChangeLang;

    public void InitService()
    {
        LoadLangsFiles();

        LoadCurrentLangId();

        SetCurrentLang(CurrentLangId);
    }

    private void LoadLangsFiles()
    {
        Langs = new Dictionary<string, Lang>();

        var files = Resources.LoadAll(LangsPath);

        if (files == null)
        {
            Debug.Log("Langs Files is null");
            return;
        }

        foreach (var file in files)
        {
            var loadedLang = JsonUtility.FromJson<Lang>(file.ToString());

            Langs.Add(file.name, loadedLang);
        }
    }

    public void SetCurrentLang(string langName)
    {
        CurrentLangDict = new Dictionary<string, string>();

        Lang current = Langs[langName];

        foreach (var wordsPair in current.words)
        {
            var currentPair = wordsPair.Split(new char[] {':'});

            CurrentLangDict.Add(currentPair[0].Trim(), currentPair[1].Trim());
        }

        SaveCurrentLangId(langName);
    }

    public void SwitchLang(string langName)
    {
        if (langName != CurrentLangId)
        {
            if (Langs.ContainsKey(langName))
            {
                CurrentLangId = langName;

                SetCurrentLang(langName);

                OnChangeLang?.Invoke();
            }

            SaveCurrentLangId(langName);
        }
    }
    public string GetPhrase(string key)
    {
        if (CurrentLangDict == null)
        {
            Debug.Log("Translates not avaliable");

            return "sample";
        }

        if (!CurrentLangDict.TryGetValue(key, out string phrase))
        {
            Debug.Log($"Translate key {key} not present in translate dictionary");
        }

        return phrase;
    }

    private void LoadCurrentLangId()
    {
        if (!PlayerPrefs.HasKey(LangKey))
        {
            PlayerPrefs.SetString(LangKey, DefaultLang);
        }

        CurrentLangId = PlayerPrefs.GetString(LangKey);

        SaveCurrentLangId(CurrentLangId);
    }

    private void SaveCurrentLangId(string lang)
    {
        PlayerPrefs.SetString(LangKey, lang);
    }
}

[System.Serializable]
public class Lang
{
    public List<string> words;

    public Lang()
    {
        words = new List<string>();
    }
}