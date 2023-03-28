using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FactoryBlock<T> : BaseMonoFactory<Block>
{
    protected string _type;

    protected int _healthCount;

    protected Sprite _sprite;

    protected Sprite _icon;

    protected Color _effectColor;

    public FactoryBlock(Block prefab, Transform container, string type, int healthCount, Sprite sprite, Color effectColor) : base(prefab, container)
    {
        _type = type;

        _healthCount = healthCount;

        _sprite = sprite;

        _effectColor= effectColor;
    }


    public override Block CreateObject()
    {
        Block newBlock = base.CreateObject();

        newBlock.Construct(_type, _healthCount, _sprite, _effectColor);

        return newBlock;
    }
}
