using DG.Tweening;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonElement : Button ,IAnimatedElement
{
    protected Action OnDownAction;

    protected Action OnUpAction;

    protected const float animateDuration = 0.25f;

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (OnDownAction == null)
            return;

        AudioController.Instance.GetButtonClickSound();

        InAnimation();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (OnUpAction == null)
            return;
        AudioController.Instance.GetButtonClickSound();

        OnUpAction.Invoke();
    }

    public void SetDownAction(Action act, bool add) => OnDownAction = add ? OnDownAction += act : OnDownAction -= act;

    public void SetUpAction(Action act, bool add) => OnUpAction = add ? OnUpAction += act : OnUpAction -= act;

    public virtual void InAnimation()
    {
        Inputs.Instance.TurnOff(true);

        DOTween.Sequence().
        AppendCallback(() => OnDownAction.Invoke()).
        Append(transform.DOShakeRotation(animateDuration, 90)).
        AppendCallback(() => Inputs.Instance.TurnOn(true));
    }

    public virtual void OutAnimation()
    {
    }
}
