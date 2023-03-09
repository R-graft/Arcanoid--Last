using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TranslatesData", menuName = "Localization/newTranslatesData", order = 1)]
[System.Serializable]
public class WordList : ScriptableObject
{
    public List<string> languages = new List<string>();

    public List<Word> words = new List<Word>();
}

[System.Serializable]
public class Word
{
    public string key = "";

    public List<LangPhrase> phrases = new List<LangPhrase>();

    public bool hide;

    public Word()
    {
    }
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
}

[System.Serializable]
public class LangPhrase
{
    public string langName;

    public string phrase;
}
