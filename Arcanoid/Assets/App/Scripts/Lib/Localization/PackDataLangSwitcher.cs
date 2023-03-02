using UnityEngine;

public class PackDataLangSwitcher : MonoBehaviour
{
    [SerializeField]
    private WordList _wordList;

    private void SetPackDataLang(int _langId)
    {
        if (!GameProgressController.Instance)
        {
            Debug.Log("ProgressController not exist");
            return;
        }

        var models = GameProgressController.Instance.PacksController.PacksModels;

        for (int i = 0; i < models.Length; i++)
        {
            if (models[i].packIndex.ToString() == _wordList.words[i].key)
                models[i].title = _wordList.words[i].phrases[_langId].phrase;
            else
                Debug.Log("PackData lang not match");
        }
    }
    private void OnEnable()
    {
        LangSwitcher.OnLangSwitch += SetPackDataLang;
    }
    private void OnDisable()
    {
        LangSwitcher.OnLangSwitch -= SetPackDataLang;
    }
}
