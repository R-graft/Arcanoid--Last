using UnityEngine;

public class ParentBonusBlock : BoostBlock
{
    protected Bonus _childBonus;

    protected virtual void SetChildBonus()
    {
    }

    public override void BoostEffect()
    {
        SetChildBonus();

        _childBonus.gameObject.SetActive(true);

        _childBonus.transform.parent = null;
    }
}
