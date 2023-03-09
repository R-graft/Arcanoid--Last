using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SaveLang 
{
    public List<string> languages;
    public List<Word> words;
}

public class LangEditor : EditorWindow
{
    public WordList langTranslates;

    public string findWord = "";

    public Vector2 scroll;

    public bool setKeyLangWord;

    public int tab;

    private int oldTap = 0;

    private string saveLoadStatus;

    private readonly string TranslationsDataFile = "/Translates.json";

    [MenuItem("Editors/LangsEditor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(LangEditor));
    }

    private void GuiLine(int i_height = 1)
    {
        Rect rect = EditorGUILayout.GetControlRect(false, i_height);

        rect.height = i_height;

        EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
    }

    private void OnFocus()
    {
        GetWindow(typeof(LangEditor)).minSize = new Vector2(500, 300);
    }

    private void OnGUI()
    {
        if (Application.isPlaying)
        {
            GUILayout.Label("In play mode editing not supported", EditorStyles.boldLabel, GUILayout.Width(position.width));
          
            return;
        }
        if (langTranslates == null)
        {
            GUILayout.Label("Cant find LangController on scene", EditorStyles.boldLabel, GUILayout.Width(position.width));

            langTranslates = EditorGUILayout.ObjectField("Asset: ", langTranslates, typeof(WordList), true) as WordList;

            return;
        }

        if (langTranslates == null)
        {
            GUILayout.Label("Set WordList on LangController.assets", EditorStyles.boldLabel, GUILayout.Width(position.width));

            return;
        }

        tab = GUILayout.Toolbar(tab, new string[] { "Words", "Languages" });

        if (oldTap != tab)
        {
            oldTap = tab;
            GUI.FocusControl(null);
        }

        if (tab == 0)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Search: ", EditorStyles.boldLabel, GUILayout.Width(100));
            findWord = EditorGUILayout.TextArea(findWord, GUILayout.Width(position.width - 120));
            GUILayout.EndHorizontal();
            setKeyLangWord = GUILayout.Toggle(setKeyLangWord, "Key = First lang", GUILayout.Width(200));
            GUILayout.Space(20);
            var words = langTranslates.words;

            if (GUILayout.Button("Add Word"))
            {
                words.Insert(0, new Word(langTranslates));
                findWord = "";
            }

            GUILayout.Space(20);
            GUILayout.Label("Words: ", EditorStyles.boldLabel);
            scroll = GUILayout.BeginScrollView(scroll, GUILayout.Width(position.width), GUILayout.Height(position.height - 180));

            int id = 0;
            foreach (var item in words)
            {
                if (findWord.Trim() != "")
                {
                    bool isDraw = false;

                    for (int i = 0; i < item.phrases.Count; i++)
                    {
                        if (item.phrases[i].phrase.ToLower().Contains(findWord.ToLower()))
                        {
                            isDraw = true;
                        }
                    }
                    if (!isDraw) continue;
                }

                id++;
                GUILayout.BeginHorizontal();
                GUILayout.BeginHorizontal(GUILayout.Width(100));

                if (!setKeyLangWord)
                {
                    GUILayout.Label("Key : ", GUILayout.Width(40));
                    item.key = EditorGUILayout.TextArea(item.key);
                }
                else
                {
                    GUILayout.Label("Key : ", GUILayout.Width(40));
                    GUILayout.Label(item.key);
                }

                GUILayout.EndHorizontal();

                if (GUILayout.Button("Show/Hide"))
                {
                    item.hide = !item.hide;
                    GUI.FocusControl(null);
                    return;
                }
                if (GUILayout.Button("Remove"))
                {
                    langTranslates.words.Remove(item);
                    GUI.FocusControl(null);
                    return;
                }
                GUILayout.EndHorizontal();

                if (!item.hide)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.BeginVertical();
                    for (int i = 0; i < item.phrases.Count; i++)
                    {
                        GUILayout.BeginHorizontal();
                        GUILayout.Label(item.phrases[i].langName + ": ", GUILayout.Width(100));
                        var opt = new GUILayoutOption[] { GUILayout.Width(position.width - 300), GUILayout.ExpandWidth(true) };

                        item.phrases[i].phrase = EditorGUILayout.TextArea(item.phrases[i].phrase, opt);

                        if (setKeyLangWord)
                        {
                            item.key = item.phrases[0].phrase;
                        }

                        GUILayout.EndHorizontal();
                    }

                    GUILayout.EndVertical();
                    GUILayout.EndHorizontal();
                    GUILayout.Space(20);
                    id++;
                }
                GuiLine();
            }

            langTranslates.words = words;
            EditorUtility.SetDirty(langTranslates); 
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());

            GUILayout.EndScrollView();
            if (GUILayout.Button("Hide All"))
            {
                foreach (var item in words)
                {
                    item.hide = true;
                }
            }
        }

        else
        {
            GUILayout.Label("Languages List: ", EditorStyles.boldLabel, GUILayout.Width(100));

            var langs = langTranslates.languages;
            var words = langTranslates.words;

            for (int i = 0; i < langs.Count; i++)
            {
                GUILayout.BeginHorizontal();
                var old = langs[i];
                langs[i] = EditorGUILayout.TextArea(langs[i], GUILayout.Width((position.width / 2)));
                if (old != langs[i])
                {
                    for (int j = 0; j < words.Count; j++)
                    {
                        var ln = words[j].phrases.Find(x => x.langName == old);

                        if (ln != null)
                            ln.langName = langs[i];
                    }
                }
                if (GUILayout.Button("Remove", GUILayout.Width((position.width / 2) - 10)))
                {
                    for (int j = 0; j < words.Count; j++)
                    {
                        words[j].phrases.RemoveAll(x => x.langName == langs[i]);
                    }

                    langs.Remove(langs[i]);
                    return;
                }
                GUILayout.EndHorizontal();
            }

            if (GUILayout.Button("Add Language", GUILayout.Width(position.width)))
            {
                langs.Add("Language: " + langs.Count);

                for (int j = 0; j < words.Count; j++)
                {
                    words[j].phrases.Add(new LangPhrase() { langName = langs[langs.Count - 1], phrase = "" });
                }

                OnGUI();
                return;
            }
            if (GUILayout.Button("Save", GUILayout.Width(position.width)))
            {
                var save = new SaveLang();
                save.languages = langTranslates.languages;
                save.words = langTranslates.words;

                DataWriter<SaveLang> currentWriter =
                    new DataWriter<SaveLang>(save, TranslationsDataFile);

                currentWriter.SaveFileToSystem();

                saveLoadStatus = "SUCCES SAVE";
                return;
            }

            if (GUILayout.Button("Load", GUILayout.Width(position.width)))
            {
                var load = new DataReader<SaveLang>(TranslationsDataFile).ReadFileFromSystem();

                langTranslates.languages = load.languages;
                langTranslates.words = load.words;

                saveLoadStatus = "SUCCES LOAD";
                return;
            }

            GUILayout.BeginHorizontal();
            GUILayout.EndHorizontal();
            GUILayout.Label(saveLoadStatus, EditorStyles.boldLabel);
        }
    }
}
