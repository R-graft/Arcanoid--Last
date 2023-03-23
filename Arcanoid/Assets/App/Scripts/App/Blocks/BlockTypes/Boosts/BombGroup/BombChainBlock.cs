using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombChainBlock : BombBlock
{
    private Dictionary<string, List<Vector2>> _startList;
    
    private List<(int x, int y)> _startIndexes = new List<(int, int )> { (0, 1), (0, -1), (-1, 0), (1, 0) };

    protected override void GetTargetIndexes()
    {
        _targetIndexes = new List<(int, int)>();

        for (int i = 0; i < _startIndexes.Count; i++)
        {
            _targetIndexes.Add(((int)_selfGridIndex.x + _startIndexes[i].x, (int)_selfGridIndex.y + _startIndexes[i].y));
        }
    }

    protected override void SetTargetBlocks()
    {
        _currentLevelsBlocks = _arranger.BlocksGrid;

        _currentTargets = new List<IDamageable>();

        _startList = new Dictionary<string, List<Vector2>>();

        foreach (var (x, y) in _targetIndexes)
        {
            var current = new Vector2(x, y);

            if (_currentLevelsBlocks.ContainsKey(current) && _selfGridIndex != current)
            {
                string currentTag = _currentLevelsBlocks[current].GetId();

                _startList.Add(currentTag, new List<Vector2>());

                _startList[currentTag].Add(current);

            }
        }

        if (_startList.Count > 0)
        {
            FindMaxPath();
        }
    }

    private void FindMaxPath()
    {
        foreach (var vertex in _startList)
        {
            Queue<Vector2> currentQueue = new Queue<Vector2>();

            string currentTag = vertex.Key;

            Vector2 currentPosition = vertex.Value[0];

            currentQueue.Enqueue(currentPosition);

            while (currentQueue.Count != 0)
            {
                var newPos = currentQueue.Dequeue();

                foreach (var (x, y) in _startIndexes)
                {
                    var newIndex = new Vector2(x + newPos.x, y + newPos.y);

                    if (!vertex.Value.Contains(newIndex) && _currentLevelsBlocks.ContainsKey(newIndex) && _currentLevelsBlocks[newIndex].GetId() == currentTag)
                    {
                        vertex.Value.Add(newIndex);

                        currentQueue.Enqueue(newIndex);
                    }
                }
            }
        }
        var finalList = _startList.Aggregate((l, r) => l.Value.Count > r.Value.Count ? l : r).Value;

        finalList.Reverse();

        foreach (var index in finalList)
        {
            if (_currentLevelsBlocks[index].gameObject.activeSelf && _selfGridIndex != index)
            {
                if (_currentLevelsBlocks[index].TryGetComponent(out IDamageable dam))
                {
                    _currentTargets.Add(dam);
                }
            }
        }
    }
}
