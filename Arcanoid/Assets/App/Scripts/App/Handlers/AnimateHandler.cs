using DG.Tweening;
using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class AnimateHandler : IService
{
    public void InitService()
    {
    }

    public void AnimateEnterPopUp(Transform _transform, Action inCallback)
    {
        inCallback.Invoke();

        DOTween.Sequence(_transform.DOMove(Vector2.zero, 0.3f)).Insert(0, _transform.DOScale(Vector3.one, 0.3f)).AppendCallback(inCallback.Invoke);
    }

    public void AnimateExitPopUp(Transform _transform)
    {
        DOTween.Sequence(_transform.DOMove(Vector2.up * 15, 0.3f)).Insert(0, _transform.DOScale(Vector3.zero, 0.3f));
    }

    public void AnimateEnterLoadPanel(Action inCallback)
    {

    }
    public void AnimateExitLoadPanel(Action inCallback)
    {

    }

    public void AnimateEnterPacksList(VerticalLayoutGroup packsList)
    {
        DOTween.Sequence().Append(DOTween.To(() => packsList.padding.bottom, x => packsList.padding.bottom = x, 0, 0.5f)).
            Insert(0, DOTween.To(() => packsList.spacing, x => packsList.spacing = x, 60, 0.5f));
    }

    public void AnimateExitPacksList(VerticalLayoutGroup packsList)
    {
        DOTween.Sequence().Append(DOTween.To(() => packsList.padding.bottom, x => packsList.padding.bottom = x, -270, 0.5f)).
            Insert(0, DOTween.To(() => packsList.spacing, x => packsList.spacing = x, -300, 0.5f));
    }
    public void AnimatePlatformSize(Transform platformTransform, float scaleValue)
    {
        platformTransform.DOScaleX(scaleValue, 0.2f);
    }
}
