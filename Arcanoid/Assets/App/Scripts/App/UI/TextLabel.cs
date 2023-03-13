using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLabel: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tMPro;

    [SerializeField] private string _key;

    private LangHandler _langHandler;

    private void Start()
    {
        _langHandler ??= ProjectContext.Instance.GetService<LangHandler>();

        _langHandler.OnChangeLang += ReTranslateText;

        _tMPro.text = _langHandler.GetPhrase(_key);
    }

    private void ReTranslateText(Dictionary<string, string> wordsDict)
    {
        if (_tMPro.text != null)
        {
            _tMPro.text = wordsDict[_key];

            //print(_tMPro.text);
        }
    }

    private void OnDisable()
    {
        _langHandler ??= ProjectContext.Instance.GetService<LangHandler>();

        _langHandler.OnChangeLang -= ReTranslateText;
    }
}
