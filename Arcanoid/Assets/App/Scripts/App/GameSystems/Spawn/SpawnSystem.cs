using UnityEngine;
using System.Collections.Generic;

public class SpawnSystem : GameSystem
{
    [SerializeField] private BlocksData _blocksData;

    [SerializeField] private Transform _simpleParent;

    [SerializeField] private Transform _boostParent;

    [SerializeField] private Transform _bulletParent;
    [SerializeField] private Bullet _bulletPefab;

    public BulletPool<Bullet> BulletPool { get; private set; }

    private int _bulletPoolsize = 40;

    public Dictionary<string, BaseMonoPool<Block>> pools;

    public override void InitSystem()
    {
        SpawnAllBlocks();
    }

    private void SpawnAllBlocks()
    {
        pools = new Dictionary<string, BaseMonoPool<Block>>();

        SpawnBlocks(_blocksData.simpleTypes);

        SpawnBlocks(_blocksData.boostTypes);

        SpawnBoost(_blocksData.parentBoostTypes);

        SpawnBullets();
    }

    private void SpawnBlocks(BlockType[] datas)
    {
        foreach (var blockType in datas)
        {
            var typeFactory = new FactoryBlock<Block>(blockType.block, _simpleParent, blockType.type, blockType.healthCount, blockType.sprite, blockType.effectColor);

            var TypePool = new BaseMonoPool<Block>(typeFactory, _simpleParent);

            pools.Add(blockType.type, TypePool);
        }
    }

    private void SpawnBoost(BonusType[] datas)
    {
        foreach (var blockType in datas)
        {
            var typeFactory = new BoostFactory<ParentBonusBlock>((ParentBonusBlock)blockType.block, _boostParent, blockType.type, blockType.healthCount, blockType.sprite, blockType.childBonus, blockType.icon, blockType.effectColor);

            var TypePool = new BaseMonoPool<Block>(typeFactory, _boostParent);

            pools.Add(blockType.type, TypePool);
        }
    }

    private void SpawnBullets()
    {
        var bulletFactory = new BulletFactory<Bullet>(_bulletPefab, _bulletParent);

        BulletPool = new BulletPool<Bullet>(bulletFactory, _bulletParent);
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
