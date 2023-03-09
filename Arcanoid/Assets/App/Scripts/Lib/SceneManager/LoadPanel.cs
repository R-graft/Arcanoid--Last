using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour, IAnimatedElement
{
    [SerializeField] private UIBlur _blurFont;
    [SerializeField] private Image _bgFont;

    public void InAnimation()
    {
        gameObject.SetActive(true);

        DOTween.Sequence().Append(_bgFont.DOFade(1, 0.5f)).
            Insert(0, DOTween.To(() => _blurFont.Multiplier, x => _blurFont.Multiplier = x, 1, 0.5f));
    }  

    public void OutAnimation()
    {
        DOTween.Sequence().Append(_bgFont.DOFade(0, 0.5f)).
           Insert(0, DOTween.To(() => _blurFont.Multiplier, x => _blurFont.Multiplier = x, 0, 0.5f)).
           AppendCallback(()=> gameObject.SetActive(false));
    }
}
