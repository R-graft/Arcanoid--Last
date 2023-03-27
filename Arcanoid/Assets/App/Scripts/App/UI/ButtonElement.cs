using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonElement : Button
{
    protected Action OnDownAction;

    protected Action OnUpAction;

    private AnimateHandler _animator;

    protected const float animateDuration = 0.12f;

    protected static bool _pushAcces = true;

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
        _animator ??= ProjectContext.Instance.GetService<AnimateHandler>();

        if (_pushAcces)
        {
            _pushAcces = false;

            _animator.AnimateButtonelement(transform, action, ()=>_pushAcces = true);
        }
    }
}
