using System.Collections.Generic;

public class BombChainBlock : BombBlock
{
    protected override void SetTargetIndexes()
    {
        if (gameObject.activeSelf)
        {
            _damage = -1;

            _targetIndexes = new (int, int)[] { (0, 1), (0, -1), (-1, 0), (1, 0) };

            _currentIndexes = new List<(int x, int y)>();

            var NeightboursTypes = new Dictionary<BlocksList, List<Block>>();

            var maxId = 0;

            BlocksList current = default;

            foreach (var (x, y) in _targetIndexes)
            {
                var newIndex = (selfGridIndex.x + x, selfGridIndex.y + y);

                if (_blocksSystem._gridIndexes.TryGetValue(newIndex, out Block block))
                {
                    if (!NeightboursTypes.ContainsKey(block.blockId))
                    {
                        NeightboursTypes.Add(block.blockId, new List<Block>());

                        NeightboursTypes[block.blockId].Add(block);

                        current = block.blockId;
                    }

                    else
                    {
                        NeightboursTypes[block.blockId].Add(block);

                        if (NeightboursTypes[block.blockId].Count > maxId)
                        {
                            maxId = NeightboursTypes[block.blockId].Count;

                            current = block.blockId;
                        }
                    }
                }
            }

            foreach (var item in NeightboursTypes[current])
            {
                if (_blocksSystem._gridIndexes.TryGetValue(item.selfGridIndex, out Block _))
                {
                    _currentIndexes.Add(item.selfGridIndex);
                }
            }
        }
    }
}
