using DG.Tweening;
using UnityEngine;

public abstract class UIPopUp : MonoBehaviour
{
    public abstract void InitPopUp();

    public virtual void Show()
    {
        gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    protected UIPopUpController _controller;

    protected LangHandler _langHandler;

    public void Construct(UIPopUpController controller)
    {
        _controller = controller;

        _langHandler = ProjectContext.Instance.GetService<LangHandler>();
    }

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
