using UnityEngine;

public class BoostFactory<T> : BaseMonoFactory<ParentBonusBlock>
{
    protected string _type;

    protected int _healthCount;

    protected Sprite _sprite;

    protected Sprite _icon;

    protected Color _effectColor;

    protected Bonus _childBonus;

    public BoostFactory(ParentBonusBlock prefab, Transform container, string type, int healthCount, Sprite sprite, Bonus childBonus, Sprite icon, Color effectColor) : base(prefab, container)
    {
        _type = type;

        _healthCount = healthCount;

        _sprite = sprite;

        _icon = icon;

        _childBonus = childBonus;

        _effectColor = effectColor;
    }

    public override ParentBonusBlock CreateObject()
    {
        var newBonus = base.CreateObject();

        _childBonus = Object.Instantiate(_childBonus, newBonus.transform);

        _childBonus.gameObject.SetActive(false);

        var boostsystem = LevelContext.Instance.GetSystem<BonusSystem>();

        newBonus.BoostConstruct(_type, _healthCount, _sprite, _effectColor, _icon, _childBonus, boostsystem);

        _childBonus.Construct(newBonus.transform, boostsystem);

        _childBonus.Init();

        return newBonus;
    }
}
