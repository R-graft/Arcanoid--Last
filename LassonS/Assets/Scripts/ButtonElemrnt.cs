using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonElemrnt : Button
{
    private Action OnDownAction;

    private Action OnUpAction;

    protected override void Awake()
    {
        AddDownAction(Aaa, true);
    }
    public void Aaa()
    {
        print(2);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (OnDownAction == null)
            return;
        OnDownAction.Invoke();

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (OnUpAction == null)
            print(1);
            return;
        OnUpAction.Invoke();
    }

    public void AddDownAction(Action act, bool add) => OnDownAction = add ? OnDownAction += act : OnDownAction -= act;

    public void AddUpAction(Action act, bool add) => OnUpAction = add ? OnUpAction += act : OnUpAction -= act;
}
