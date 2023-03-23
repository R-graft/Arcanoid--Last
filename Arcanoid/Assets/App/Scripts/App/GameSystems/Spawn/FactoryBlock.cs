using UnityEngine;

public class FactoryBlock<T> : BaseMonoFactory<Block>
{
    protected string _type;

    protected int _healthCount;

    protected Sprite _sprite;

    protected Sprite _icon;

    protected Bonus _childBonus;

    protected Color _effectColor;

    public FactoryBlock(Block prefab, Transform container, string type, int healthCount, Sprite sprite, Color effectColor) : base(prefab, container)
    {
        _type = type;

        _healthCount = healthCount;

        _sprite = sprite;

        _effectColor= effectColor;
    }

    public FactoryBlock(Block prefab, Transform container, string type, int healthCount, Sprite sprite, Bonus childBonus, Sprite icon, Color effectColor) : base(prefab, container)
    {
        _type = type;

        _healthCount = healthCount;

        _sprite = sprite;

        _icon = icon;

        _childBonus = childBonus;

        _effectColor = effectColor;
    }

    public Block ConstructObject()
    {
        Block newBlock = CreateObject();

        newBlock.Construct(_type, _healthCount, _sprite, _effectColor);

        return newBlock;
    }

    public Block ConstructBonus()
    {
        var newBonus = (ParentBonusBlock)ConstructObject();

        _childBonus = Object.Instantiate(_childBonus, newBonus.transform);

        _childBonus.gameObject.SetActive(false);

        var boostsystem = LevelContext.Instance.GetSystem<BonusSystem>();

        newBonus.BoostConstruct(_icon, _childBonus, boostsystem);

        _childBonus.Construct(newBonus.transform, boostsystem);

        _childBonus.Init();

        return newBonus;
    }
}
