using System.Collections.Generic;

public class CircleBombBlock : BombBlock
{
    protected override void SetTargetIndexes()
    {
        if (gameObject.activeSelf)
        {
            _damage = 2;

            _targetIndexes = new (int, int)[]
            { (0, 1), (0, -1), (-1, 0), (1, 0), (1, 1), (-1, -1), (-1, 1), (1, -1) };

            _currentIndexes = new List<(int x, int y)>();

            foreach (var (x, y) in _targetIndexes)
            {
                var newIndex = (selfGridIndex.x + x, selfGridIndex.y + y);

                if (_blocksSystem._gridIndexes.TryGetValue(newIndex, out Block _))
                    _currentIndexes.Add(newIndex);
            }
        }
    }
}

