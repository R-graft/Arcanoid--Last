using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour, IAnimatedElement
{
    [SerializeField] private Image _bg;
    [SerializeField] private Transform _loadIcon;

    private void OnEnable()
    {
        InAnimation();
    }
    public void InAnimation()
    {
        DOTween.Sequence().Append(_bg.DOFade(1, 0.3f)).
            AppendCallback(() => _loadIcon.gameObject.SetActive(true)).
            Append(_loadIcon.DORotate(new Vector3(0, 0, -720), 1, RotateMode.WorldAxisAdd));
            //SetLink(gameObject)) ;
    }  

    public void OutAnimation()
    {
        DOTween.Sequence().AppendCallback(() => _loadIcon.gameObject.SetActive(false)).
            Append(_bg.DOFade(0, 0.3f)).AppendCallback(()=> gameObject.SetActive(false));
    }
}
