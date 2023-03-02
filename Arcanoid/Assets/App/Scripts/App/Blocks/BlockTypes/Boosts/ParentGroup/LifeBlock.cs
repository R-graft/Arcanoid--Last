using UnityEngine;

public class LifeBlock : ParentBonusBlock
{
    [SerializeField]
    private LifeBonus _bonusPrefab;

    [SerializeField]
    private bool _islifeUp;

    protected override void SetChildBonus()
    {
        _bonusPrefab.isLifeUp = _islifeUp;

        _childBonus = _bonusPrefab;
    }
}
