using System.Collections.Generic;

public class VerticalBomb : BombBlock
{
    protected override void GetTargetIndexes()
    {
        for (int i = 0; i <= _grid._linesCount; i++)
        {
            _targetIndexes.Add((i, (int)_selfGridIndex.y));
        }
    }
}
