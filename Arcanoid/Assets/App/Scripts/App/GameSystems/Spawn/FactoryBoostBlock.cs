using UnityEngine;

public class FactoryBoostBlock<BoostBlock> : FactoryBlock<Block>
{
    public FactoryBoostBlock(Block prefab, Transform container, string type, int healthCount, Sprite sprite) : base(prefab, container, type, healthCount, sprite)
    {
    }

    public override Block ConstructObject()
    {
        Block newBlock = CreateObject();

        newBlock.Construct(_type, _healthCount, _sprite);

        return newBlock;
    }
}
