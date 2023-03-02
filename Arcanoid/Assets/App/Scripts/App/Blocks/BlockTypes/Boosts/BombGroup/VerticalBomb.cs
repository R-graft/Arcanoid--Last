using System.Collections.Generic;

public class VerticalBomb : BombBlock
{
    protected override void SetTargetIndexes()
    {
        if (gameObject.activeSelf)
        {
            _damage = -1;

            var linesCount = _blocksSystem.linesCount;

            _currentIndexes = new List<(int x, int y)>();

            for (int i = 1; i <= linesCount; i++)
            {
                var newIndex = (i,selfGridIndex.y);

                if (_blocksSystem._gridIndexes.TryGetValue(newIndex, out Block _))
                {
                    _currentIndexes.Add(newIndex);
                }
            }
        }
    }
}
