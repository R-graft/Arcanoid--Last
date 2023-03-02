using UnityEngine;
using System.Collections.Generic;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField]
    private BlocksData _blocksData;

    [SerializeField]
    private BlocksSystem _blockSystem;

    public static Dictionary<BlocksList, ObjectPool<Block>> Pools { get; private set; }
    
    public Dictionary<BlocksList, FactoryBlock<Block>> factories;

    public void Init()
    {
        SpawnBlocks();
    }
    private void SpawnBlocks()
	{
        Pools = new Dictionary<BlocksList, ObjectPool<Block>>();

        factories = new Dictionary<BlocksList, FactoryBlock<Block>>();

        foreach (var block in _blocksData.blocksTypes)
        {
            FactoryBlock<Block> factory = new FactoryBlock<Block>(block, _blockSystem);

            factories.Add(block.blockId, factory);

            ObjectPool<Block> pool = new ObjectPool<Block>(() => PoolOnCreateNewBlock(block), PoolOnCreate,
                PoolOnGet, PoolOnDisable);
           
            for (int i = 0; i < block.poolSize; i++)
            {
                var newObject = factory.CreateObject();

                pool.Add(newObject);
            }
            Pools.Add(block.blockId, pool);
        }
    }
    public void PoolOnGet(Block block)
    {
        block.gameObject.SetActive(true);

        block.InAnimation();
    }

    public void PoolOnCreate(Block block)
    {
        block._blockSprite.size = Vector2.zero;

        block.gameObject.SetActive(false);
    }

    public void PoolOnDisable(Block block)
    {
        block.OutAnimation();
    }

    public Block PoolOnCreateNewBlock(Block block)
    {
        return factories[block.blockId].CreateObject();
    }
}
