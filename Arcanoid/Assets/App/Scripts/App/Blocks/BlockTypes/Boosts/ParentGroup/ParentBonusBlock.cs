using UnityEngine;

public class ParentBonusBlock : BoostBlock ,IDamageable
{
    [SerializeField] private SpriteRenderer _icon;

    private BonusSystem _boosts;

    protected Bonus _childBonus;

    public void BoostConstruct(string id, int health, Sprite sprite, Color effectColor, Sprite icon, Bonus bonus, BonusSystem boosts)
    {
        base.Construct(id, health, sprite, effectColor);

        _icon.sprite = icon;

        _childBonus = bonus;

        _boosts = boosts; 
    }

    public override void BoostEffect()
    {
        _childBonus.transform.parent = null;

        _childBonus.gameObject.SetActive(true);
    }
}
