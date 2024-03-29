using System.Collections.Generic;
using UnityEngine;

public class UIPopUpController : MonoBehaviour, IService
{
    [SerializeField] private List<PopUpObject> _popList;

    [SerializeField] private RectTransform _parentTranform;

    private UIPopUp _currentPopUp;

    private Stack<UIPopUp> _popUpHistory = new Stack<UIPopUp>();

    private Dictionary<string, UIPopUp> _popUpDictionary = new Dictionary<string, UIPopUp>();

    public void InitService()
    {
        foreach (var pop in _popList)
        {
            var newPopUp = Instantiate(pop.popUp, _parentTranform);

            newPopUp.gameObject.SetActive(false);

            newPopUp.Construct(this);

            newPopUp.Hide();

            newPopUp.InitPopUp();

            _popUpDictionary.Add(pop.popId, newPopUp);
        }
    }
    public void ShowPop(string id, bool remember = false)
    {
        if (_popUpDictionary.ContainsKey(id))
        {
            if (_currentPopUp)
            {
                _currentPopUp.Hide();
            }

            _currentPopUp = _popUpDictionary[id];

            _currentPopUp.Show();

            if (remember)
            {
                _popUpHistory.Push(_currentPopUp);
            }
        }

        else
        {
            Debug.Log("PopID not present in dictionary");
        }
    }

    public void ShowPopType(UIPopUp pop)
    {
        foreach (var currentPop in _popList)
        {
            if (currentPop.popUp == pop)
            {
                _currentPopUp.Hide();

                _currentPopUp = currentPop.popUp;

                _currentPopUp.Show();
            }
        }
    }

    public void ShowLast()
    {
        ShowPopType(_popUpHistory.Pop());
    }

    public void HidePop()
    {
        if (_currentPopUp)
        {
        _currentPopUp.Hide();
        }
        _currentPopUp= null;
    }
}

[System.Serializable]
public class PopUpObject
{
    public string popId;

    public UIPopUp popUp;
}
