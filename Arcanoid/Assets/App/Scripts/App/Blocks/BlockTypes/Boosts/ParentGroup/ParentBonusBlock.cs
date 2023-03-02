using UnityEngine;

public class ParentBonusBlock : BoostBlock
{
    protected Bonus _childBonus;

    private readonly Vector2 _childStartscale = new Vector2(0.6f, 0.6f);

    protected virtual void SetChildBonus()
    {
    }

    public override void BoostEffect()
    {
        SetChildBonus();

        _childBonus.gameObject.SetActive(true);

        _childBonus.transform.parent = null;

        _childBonus.transform.localScale = _childStartscale;
    }
}
