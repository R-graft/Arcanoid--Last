using UnityEngine;
using System.Collections.Generic;

public class SpawnSystem : GameSystem
{
    [SerializeField] private BlocksData _blocksData;

    public Dictionary<string, BaseMonoPool<Block>> pools;
    
    public Dictionary<string, FactoryBlock<Block>> factories;

    public override void InitSystem()
    {
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        pools = new Dictionary<string, BaseMonoPool<Block>>();

        factories = new Dictionary<string, FactoryBlock<Block>>();

        SpawnSimple(_blocksData.simpleTypes);

        SpawnBoost(_blocksData.boostTypes);

        SpawnParentBoost(_blocksData.boostTypes);
    }

    private void SpawnSimple(SimpleType[] datas)
    {
        foreach (var blockType in datas)
        {
            var typeFactory = new FactoryBlock<Block>(blockType.block, transform, blockType.type, blockType.healthCount, blockType.sprite);

            factories.Add(blockType.type, typeFactory);

            var TypePool = new BaseMonoPool<Block>(typeFactory, transform);

            pools.Add(blockType.type, TypePool);

            for (int i = 0; i < blockType.poolsize; i++)
            {
                var newBlock = typeFactory.ConstructObject();

                TypePool.ReturnObject(newBlock);
            }
        }
    }

    private void SpawnBoost(SimpleType[] datas)
    {

    }

    private void SpawnParentBoost(SimpleType[] datas)
    {

    }

    public Block GetBlock(string tag)
    {
        return pools[tag].GetObject();
    }

    public void ReturnBlock(Block block)
    {
        pools[block.GetId()].ReturnObject(block);
    }
}
