using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIPopUp : MonoBehaviour
{
    [SerializeField] private Image _bg;

    [SerializeField] private Transform _content;

    protected UIPopUpController _controller;

    protected LangHandler _langHandler;

    protected AnimateHandler _animator;

    protected float _enterAnimHold = 0f;

    protected float _exitAnimHold;

    public abstract void InitPopUp();

    public virtual void Show()
    {
        _animator.AnimateEnterPopUp(_content, _bg, _enterAnimHold, ()=> gameObject.SetActive(true));
    }

    public virtual void Hide()
    {
        _animator.AnimateExitPopUp(_content, _bg, _exitAnimHold, () => gameObject.SetActive(false));
    }

    public void Construct(UIPopUpController controller)
    {
        _controller = controller;

        _animator = ProjectContext.Instance.GetService<AnimateHandler>();

        _langHandler = ProjectContext.Instance.GetService<LangHandler>();
    }
}
