using UnityEngine;

public class FactoryBlock<T> : BaseMonoFactory<Block>
{
    protected string _type;

    protected int _healthCount;

    protected Sprite _sprite;

    public FactoryBlock(Block prefab, Transform container, string type, int healthCount, Sprite sprite) : base(prefab, container)
    {
        _type= type;

        _healthCount= healthCount;

        _sprite= sprite;
    }

    public virtual Block ConstructObject()
    {
        Block newBlock = CreateObject();

        newBlock.Construct(_type, _healthCount, _sprite);

        return newBlock;
    }
}
