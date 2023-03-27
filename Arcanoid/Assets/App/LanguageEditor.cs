using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace Test 
{
    public class LanguageEditor : MonoBehaviour
    {
        private List<Word> _langs;

        private Dictionary<string, string> _currentLang;
        public string CurrentLang { get; private set; }

        private const string LangsPath = "/langs/newLang.json";

        private const string LangKey = "CurrentLangKey";

        private const string DefaultLang = "eng";

        private void Awake()
        {
            //new DataWriter<Lang>(newlan, LangsPath).SaveFileToResources();
        }

        private void Init()
        {
            _langs = new DataReader<List<Word>>(LangsPath).ReadFileFromResources();
        }

        #region saveLoad
        private void LoadLang()
        {
            if (!PlayerPrefs.HasKey(LangKey))
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
        #endregion

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

    [System.Serializable]
    public class Word
    {
        public string key;
        public string value;

        public Word(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}