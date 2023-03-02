using UnityEngine;
public class PlatformSpeed : ParentBonusBlock
{
    [SerializeField]
    private PlatformSpeedBonus _bonusPrefab;

    [SerializeField]
    private bool _isSpeedUp;

    protected override void SetChildBonus()
    {
        _bonusPrefab.isSpeedUp = _isSpeedUp;

        _childBonus = _bonusPrefab;
    }
}
