using System.Collections.Generic;
using UnityEngine;

public class HorizontalBomb : BombBlock
{
    protected override void GetTargetIndexes()
    {
        base.GetTargetIndexes();

        _targetIndexes = new List<(int, int)>();

        int i = (int)_selfGridIndex.y;
        int j = (int)_selfGridIndex.y;

        for (int k = 0; k <= _grid._rowsCount; k++)
        {
            i--;
            j++;

            if (i > 0)
            {
                _targetIndexes.Add(((int)_selfGridIndex.x, i));
            }
            if (j <= _grid._rowsCount)
            {
                _targetIndexes.Add(((int)_selfGridIndex.x, j));
            }
            
        }
    }
}
