using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonElement : Button
{
    protected Action OnDownAction;

    protected Action OnUpAction;

    private Inputs _inputs;

    protected const float animateDuration = 0.12f;

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (OnDownAction == null)
            return;

        InAnimation(OnDownAction);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (OnUpAction == null)
            return;

        InAnimation(OnUpAction);
    }

    public void SetDownAction(Action act, bool add) => OnDownAction = add ? OnDownAction += act : OnDownAction -= act;

    public void SetUpAction(Action act, bool add) => OnUpAction = add ? OnUpAction += act : OnUpAction -= act;

    public virtual void InAnimation(Action action)
    {
        if (_inputs == null)
        {
            _inputs = ProjectContext.Instance.GetService<Inputs>();
        }

        _inputs.TurnOff(true);

        DOTween.Sequence().
        AppendCallback(() => action.Invoke()).
        Append(transform.DOScale(new Vector2(0.8f, 0.8f), animateDuration)).Append(transform.DOScale(Vector2.one, animateDuration)).
        AppendCallback(() => _inputs.TurnOn(true));
    }
}
