using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour, IAnimatedElement
{
    [SerializeField] private Image _bgFont;

    public void InAnimation()
    {
        gameObject.SetActive(true);

        DOTween.Sequence().Append(_bgFont.DOFade(1, 0.7f));
    }  

    public void OutAnimation()
    {
        DOTween.Sequence().Append(_bgFont.DOFade(0, 0.7f)).
           AppendCallback(()=> gameObject.SetActive(false));
    }
}
