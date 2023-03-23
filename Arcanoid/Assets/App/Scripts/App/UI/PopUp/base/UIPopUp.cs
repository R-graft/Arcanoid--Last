using DG.Tweening;
using UnityEngine;

public abstract class UIPopUp : MonoBehaviour
{
    protected UIPopUpController _controller;

    protected LangHandler _langHandler;

    protected AnimateHandler _animator;

    public virtual void InitPopUp()
    {
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);

        _animator.AnimateEnterPopUp(transform, () => Time.timeScale = 0);
    }

    public virtual void Hide()
    {
        Time.timeScale = 1;

        _animator.AnimateExitPopUp(transform);
    }

    public void Construct(UIPopUpController controller)
    {
        _controller = controller;

        _animator = ProjectContext.Instance.GetService<AnimateHandler>();

        _langHandler = ProjectContext.Instance.GetService<LangHandler>();
    }
}
