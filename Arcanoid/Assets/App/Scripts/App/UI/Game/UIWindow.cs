using DG.Tweening;
using UnityEngine;

[System.Serializable]
public abstract class UIWindow<T> : MonoBehaviour, IAnimatedElement
{
    public abstract void InitWindow(T UIParent);

    public virtual void ShowWindow() => InAnimation();

    public virtual void HideWindow() => OutAnimation();

    public virtual void InAnimation()
    {
        gameObject.SetActive(true);

        DOTween.Sequence().Append(transform.DOMoveY(8, 0.1f)).Append(transform.DOMoveY(10, 0.1f));
    }

    public virtual void OutAnimation()
    {
        DOTween.Sequence().Append(transform.DOMoveY(8, 0.1f)).Append(transform.DOMoveY(25, 0.1f)).
        AppendCallback(()=> gameObject.SetActive(false));
    }

}
