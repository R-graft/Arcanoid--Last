using UnityEngine;

public class PlatformResize : ParentBonusBlock
{
    [SerializeField]
    private PlatformResizeBonus _bonusPrefab;

    [SerializeField]
    private float _resizeValue;

    protected override void SetChildBonus()
    {
        _bonusPrefab.resizeValue = _resizeValue;

        _childBonus = _bonusPrefab;
    }
}
