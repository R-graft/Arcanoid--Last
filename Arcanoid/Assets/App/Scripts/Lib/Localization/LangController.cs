using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LangController : MonoBehaviour
{
    public WordList translatesData;

    [SerializeField]
    private List<TextTranslator> _sceneTexts;

    private Dictionary<string, Word> dictionary = new Dictionary<string, Word>();

    private int _currenLang;

    public void Awake()
    {
        _currenLang = PlayerPrefs.GetInt("CurrentLangIndex");

        ChangeLang(_currenLang);
    }

    public void ChangeLang(int langId)
    {
        dictionary = new Dictionary<string, Word>();

        if (translatesData)
        {
            foreach (var item in translatesData.words)
            {
                dictionary.Add(item.key, new Word(item));
            }

            ReTranslateText(langId);

            PlayerPrefs.SetInt("CurrentLangIndex", langId);
        }

        else
        {
            Debug.Log("Set Translation Asset!");
        }

    }
    private void ReTranslateText(int langId)
    {
        foreach (var text in _sceneTexts)
        {
            if (text.t != null)
                text.t.text = dictionary[text.key].phrases[langId].phrase;
            else if (text.tMp != null)
                text.tMp.text = dictionary[text.key].phrases[langId].phrase;
            else if (text.tMps != null)
            {
                foreach (var text_ in text.tMps)
                    text_.text = dictionary[text.key].phrases[langId].phrase;
            }
            else if(text.ts != null)
            {
                foreach (var text_ in text.ts)
                    text_.text = dictionary[text.key].phrases[langId].phrase;
            }
        }
    }

    private void OnEnable()
    {
        LangSwitcher.OnLangSwitch += ChangeLang;
    }
    private void OnDisable()
    {
        LangSwitcher.OnLangSwitch -= ChangeLang;
    }
}

[System.Serializable]
public class TextTranslator
{
    public string key;

    public Text t;

    public TMP_Text tMp;

    public TMP_Text[] tMps;

    public Text[] ts;
}

[System.Serializable]
public class LangPhrase
{
    public string langName;

    public string phrase;
}

[System.Serializable]
public class Word
{
    public string key = "";

    public List<LangPhrase> phrases = new List<LangPhrase>();

    public bool hide = true;

    public Word(WordList data)
    {
        for (int i = 0; i < data.languages.Count; i++)
        {
            phrases.Add(new LangPhrase() { langName = data.languages[i], phrase = "" });
        }
    }
    public Word(Word wordKey)
    {
        for (int i = 0; i < wordKey.phrases.Count; i++)
        {
            phrases.Add(wordKey.phrases[i]);
        }
    }
    public Word()
    {
    }
}
