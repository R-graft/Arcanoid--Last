using System.Collections.Generic;

public class VerticalBomb : BombBlock
{
    protected override void GetTargetIndexes()
    {
        base.GetTargetIndexes();

        int i = (int)_selfGridIndex.x;
        int j = (int)_selfGridIndex.x;

        for (int k = 0; k <= _grid._linesCount; k++)
        {
            i--;
            j++;

            if (i > 0)
            {
                _targetIndexes.Add((i, (int)_selfGridIndex.y));
            }
            if (j <= _grid._linesCount)
            {
                _targetIndexes.Add((j, (int)_selfGridIndex.y));
            }
        }
    }
}
