using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour
{
    [SerializeField] private Image _bgFont;

    private AnimateHandler _animator;

    private void InitAnimator()
    {
        _animator ??= ProjectContext.Instance.GetService<AnimateHandler>();
    }
    public void InAnimation()
    {
        InitAnimator();

        gameObject.SetActive(true);

        DOTween.Sequence().Append(_bgFont.DOFade(1, 0.5f));
    }  

    public void OutAnimation()
    {
        InitAnimator();

        DOTween.Sequence().Append(_bgFont.DOFade(0, 0.5f)).
           AppendCallback(()=> gameObject.SetActive(false));
    }
}
