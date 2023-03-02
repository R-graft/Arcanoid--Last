using DG.Tweening;
using UnityEngine;

public class PackButton : ButtonElement
{
    public override void InAnimation()=>
        DOTween.Sequence().Append(transform.DOScale(new Vector2(2, 2), 0.1f)).AppendCallback(OnDownAction.Invoke);
}
