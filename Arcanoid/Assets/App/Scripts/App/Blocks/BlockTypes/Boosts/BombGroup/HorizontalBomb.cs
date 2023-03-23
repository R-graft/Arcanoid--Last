using UnityEngine;

public class HorizontalBomb : BombBlock
{
    protected override void GetTargetIndexes()
    {
        for (int i = 0; i <= _grid._rowsCount; i++)
        {
            _targetIndexes.Add(((int)_selfGridIndex.x, i));
        }
    }
}
