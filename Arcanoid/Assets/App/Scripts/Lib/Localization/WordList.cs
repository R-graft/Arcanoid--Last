using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TranslatesData", menuName = "Localization/newTranslatesData", order = 1)]
public class WordList : ScriptableObject
{
    public List<string> languages = new List<string>();

    public List<Word> words = new List<Word>();
}
