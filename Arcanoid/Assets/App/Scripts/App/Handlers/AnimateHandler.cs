using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AnimateHandler : IService
{
    private Sequence popUpSequence;
    public void InitService()
    {
    }

    public void AnimateEnterPopUp(Transform _content, Image bg, float fadeTime, Action inCallback)
    {
        if (popUpSequence.IsActive())
            popUpSequence.Kill();

        inCallback.Invoke();
        popUpSequence = DOTween.Sequence().Append(bg.DOFade(1, fadeTime)).Append(DOTween.Sequence().Insert(0, _content.DOMove(Vector2.zero, 0.3f)).Insert(0, _content.DOScale(Vector3.one, 0.3f))).SetAutoKill();
    }

    public void AnimateExitPopUp(Transform content, Image bg, float fadeTime, Action callback)
    {
        popUpSequence = DOTween.Sequence().Append(bg.DOFade(0, fadeTime)).Insert(0, content.DOMove(Vector2.up * 15, 0.3f)).Insert(0, content.DOScale(Vector3.zero, 0.3f)).AppendCallback(callback.Invoke).SetAutoKill();
    }

    public void AnimateEnterLoadPanel(Image bg, RectTransform line1, RectTransform line2, RectTransform line3)
    {
        DOTween.Sequence().Append(bg.DOFade(1, 0.5f))
            .Insert(0, line1.DOAnchorPos(new Vector2(0, 700f), 0.5f))
            .Insert(0, line2.DOAnchorPos(new Vector2(0, 0), 0.5f))
            .Insert(0, line3.DOAnchorPos(new Vector2(0, -700f), 0.5f));
    }
    public void AnimateExitLoadPanel(Image bg, RectTransform line1, RectTransform line2, RectTransform line3, Action outCallback)
    {
        DOTween.Sequence().Append(bg.DOFade(0, 0.5f))
            .Insert(0, line1.DOAnchorPos(new Vector2(1000f, 1700f), 0.5f))
            .Insert(0, line2.DOAnchorPos(new Vector2(-1300, -1300), 0.5f))
            .Insert(0, line3.DOAnchorPos(new Vector2(1300, 600), 0.5f))
            .AppendCallback(outCallback.Invoke);
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

    public void AnimateButtonelement(Transform button, Action inCallback, Action outCallback)
    {
        DOTween.Sequence().
        AppendCallback(inCallback.Invoke).
        Append(button.DOScale(new Vector2(0.8f, 0.8f), 0.12f)).Append(button.DOScale(Vector2.one, 0.12f)).
        AppendCallback(outCallback.Invoke);
    }

    public void AnimateEnergyChange(Image image, Action hide)
    {
        var currentSequence = DOTween.Sequence().Append(image.DOFade(0.7f, 0.3f)).Append(image.DOFade(0, 0.3f));

        if (hide!= null)
        {
            currentSequence.AppendCallback(hide.Invoke);
        }
    }

    public void AnimateNotEnergy()
    {

    }
}
