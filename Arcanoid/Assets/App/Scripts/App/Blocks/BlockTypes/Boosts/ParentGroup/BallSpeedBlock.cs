using UnityEngine;

public class BallSpeedBlock : ParentBonusBlock
{
    [SerializeField]
    private BallSpeedBonus _bonusPrefab;

    [SerializeField]
    private bool _isSpeedUp;

    protected override void SetChildBonus()
    {
        _bonusPrefab.isSpeedUp = _isSpeedUp;

        _childBonus = _bonusPrefab;
    }
}
