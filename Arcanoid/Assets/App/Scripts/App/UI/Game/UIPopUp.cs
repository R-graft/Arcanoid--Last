using DG.Tweening;
using UnityEngine;

public abstract class UIPopUp : MonoBehaviour
{
    public abstract void InitPopUp();

    public virtual void Show() => gameObject.SetActive(true);

    public virtual void Hide() => gameObject.SetActive(false);

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
