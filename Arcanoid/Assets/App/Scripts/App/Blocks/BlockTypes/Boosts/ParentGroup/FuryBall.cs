using UnityEngine;

public class FuryBall : ParentBonusBlock
{
    [SerializeField]
    private FuryBallBonus _furyBallBonusPrefab;

    protected override void SetChildBonus() => _childBonus = _furyBallBonusPrefab;

}
