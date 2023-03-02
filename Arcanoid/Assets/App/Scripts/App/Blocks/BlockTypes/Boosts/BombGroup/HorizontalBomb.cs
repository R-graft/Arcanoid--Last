using System.Collections.Generic;

public class HorizontalBomb : BombBlock
{
    protected override void SetTargetIndexes()
    {
        if (gameObject.activeSelf)
        {
            _damage = -1;

            var rowsCount = _blocksSystem.linesCount;

            _currentIndexes = new List<(int x, int y)>();

            for (int i = 1; i <= rowsCount; i++)
            {
                var newIndex = (selfGridIndex.x, i);

                if (_blocksSystem._gridIndexes.TryGetValue(newIndex, out Block _))
                {
                    _currentIndexes.Add(newIndex);
                }
            }
        }
    }
}
