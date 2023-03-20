using UnityEngine;

public class ParentBonusBlock : BoostBlock ,IDamageable
{
    [SerializeField] private SpriteRenderer _icon;

    private BonusSystem _boosts;

    protected Bonus _childBonus;

    public void BoostConstruct(Sprite sprite, Bonus bonus, BonusSystem boosts)
    {
        _icon.sprite = sprite;

        _childBonus = bonus;

        _boosts = boosts; 
    }

    public override void BoostEffect()
    {
        _childBonus.transform.parent = null;

        _childBonus.gameObject.SetActive(true);
    }
}
