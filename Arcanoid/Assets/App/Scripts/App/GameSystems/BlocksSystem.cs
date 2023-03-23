using System;
using System.Collections.Generic;

public class BlocksSystem : GameSystem
{
    private List<Block> _allBlocks = new List<Block>();

    private SpawnSystem _spawner;

    private BlocksArrangeSystem _arranger;

    public Action<int> OnBlockDestroyed;

    private int _currentCount;
    public override void InitSystem()
    {
        _spawner = LevelContext.Instance.GetSystem<SpawnSystem>();

        _arranger = LevelContext.Instance.GetSystem<BlocksArrangeSystem>();

        _arranger.OnAddNewBlock += AddBlock;
    }

    public override void ReStartSystem()
    {
        ClearBlocks();
    }

    public void AddBlock(Block block)
    {
        if (!block.nonDamageable)
        {
            _currentCount++;
        }

        _allBlocks.Add(block);
    }

    public void RemoveBlock(Block block)
    {
        if (_allBlocks.Contains(block))
        {
            if (!block.nonDamageable)
            {
                OnBlockDestroyed.Invoke(_currentCount);

                _currentCount--;
            }

            _allBlocks.Remove(block);

            _spawner.ReturnBlock(block);

            block.RefreshBlock();

            if (_currentCount == 0)
            {
                _controller.Win();
            }
        }
    }

    public void ClearBlocks()
    {
        foreach (var block in _allBlocks)
        {
            block.RefreshBlock();

            _spawner.ReturnBlock(block);
        }

        _allBlocks.Clear();

        _currentCount = 0;
    }

    public void SetBlocksCollider(bool isTrigger)
    {
        foreach (var block in _allBlocks)
        {
            block.GetCollider().isTrigger = isTrigger;
        }
    }
}

