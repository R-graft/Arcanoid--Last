using System.Collections.Generic;

public class BlocksSystem : GameSystem
{
    private List<Block> _allBlocks = new List<Block>();

    private SpawnSystem _spawner;
    public override void InitSystem()
    {
        _spawner = LevelContext.Instance.GetSystem<SpawnSystem>();
    }

    public void AddBlock(Block block)
    {
        _allBlocks.Add(block);
    }

    public void RemoveBlock(Block block)
    {
        if (_allBlocks.Contains(block))
        {
            _spawner.ReturnBlock(block);

            _allBlocks.Remove(block);

            if (_allBlocks.Count == 0)
            {
                _controller.Win();
            }
        }
    }

    public void ClearBlocks()
    {
        foreach (var block in _allBlocks)
        {
            _spawner.ReturnBlock(block);
        }

        _allBlocks.Clear();
    }
}

