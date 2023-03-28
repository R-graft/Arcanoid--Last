using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour
{
    [SerializeField] private Image _bgFont;

    [SerializeField] private RectTransform _line1; 
    [SerializeField] private RectTransform _line2; 
    [SerializeField] private RectTransform _line3;

    private AnimateHandler _animator;

    private void InitAnimator()
    {
        _animator ??= ProjectContext.Instance.GetService<AnimateHandler>();
    }
    public void InAnimation()
    {
        _line1.anchoredPosition = new Vector2(1000, 1700);
        _line2.anchoredPosition = new Vector2(-1300, -1300);
        _line3.anchoredPosition = new Vector2(1300, 600);

        InitAnimator();

        gameObject.SetActive(true);

        _animator.AnimateEnterLoadPanel(_bgFont, _line1, _line2, _line3);
    }  

    public void OutAnimation()
    {
        InitAnimator();

        _animator.AnimateExitLoadPanel(_bgFont, _line1, _line2, _line3, ()=> gameObject.SetActive(false));
    }
}
