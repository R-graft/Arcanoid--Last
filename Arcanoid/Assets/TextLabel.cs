using TMPro;
using UnityEngine;

public class TextLabel: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tMPro;

    [SerializeField] private string _key;

    private LangHandler _langHandler;

    private void Start()
    {
        _langHandler = MainServiceLocator.Instance.GetService<LangHandler>();

        _langHandler.OnChangeLang += ReTranslateText;
    }
    public void ReTranslateText(string phrase)
    {
        if (_tMPro != null)
        {
            _tMPro.text = phrase;
        }
    }

    private void OnDisable()
    {
        _langHandler.OnChangeLang -= ReTranslateText;
    }
}
