using System.Collections.Generic;

public class CircleBomb : BombBlock
{
    protected override void GetTargetIndexes()
    {
        _damagingHold = 0;

        _targetIndexes = new List<(int, int)> { (0, -1), (-1, 0), (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (-1, -1) };

        for (int i = 0; i < _targetIndexes.Count; i++)
        {
            _targetIndexes[i] = ((int)_selfGridIndex.x + _targetIndexes[i].x, (int)_selfGridIndex.y + _targetIndexes[i].y);
        }
    }
}

