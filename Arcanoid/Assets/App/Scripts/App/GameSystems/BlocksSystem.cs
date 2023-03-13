using System;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSystem : MonoBehaviour
{
    [Header("config")]
    public int rowsCount = 7;
    public int linesCount = 7;

    [SerializeField] private BlocksArrangeSystem _blocksArranger;

    private int _currentBlocksCount;

    private Vector2 _blockSize;

    public Dictionary<(int x, int y), Block> _gridIndexes = new Dictionary<(int x, int y), Block>();

    public Dictionary<(int x, int y), Vector2> _gridWorldPositions;

    public static Action OnBlockDestroyed;

    public static Action OnAllBlocksDestroyed;

    public void Init()
    {
        //_grid = new FieldGridSystem(rowsCount, linesCount);

        //_gridWorldPositions = _grid.CreateGrid();

        //_blockSize = _grid.GetBlocksSize();

        BlocksArrangeSystem.OnGetBlocksCount += SetStartBlocksCount;
    }

    public void StartSystem()
    {
        ClearBlocks();

        _gridIndexes = new Dictionary<(int x, int y), Block>();

        _blocksArranger.GetBlocks(_gridWorldPositions, _gridIndexes, _blockSize);
    }

    public void BlockRemove((int x, int y) index)
    {
        if (_gridIndexes.TryGetValue(index, out Block block))
        {
            if (block.TryGetComponent(out IDamageable _))
            {
                BlocksCounter(1);
            }

            _gridIndexes.Remove(index);

           // SpawnSystem.Pools[block.blockId].Disable(block);
        }
    }
    public void AddBlock((int x, int y) index, Block block) => _gridIndexes.Add(index, block);

    private void BlocksCounter(int count)
    {
        _currentBlocksCount -= count;

        OnBlockDestroyed?.Invoke();

        if (_currentBlocksCount == 0)
            OnAllBlocksDestroyed?.Invoke();
    }

    public void ClearBlocks()
    {
        if (_gridIndexes != null &&_gridIndexes.Count != 0)
        {
           // foreach (var block in _gridIndexes)
               // SpawnSystem.Pools[block.Value.blockId].Disable(block.Value);
        }
    }

    private void SetStartBlocksCount(int value) => _currentBlocksCount = value;

    #region(bonus actoins)
    private void FuryModeBonus(bool isFury)
    {
        foreach (var item in _gridIndexes.Values)
        {
            //item._collider.isTrigger = isFury;
        }
    }

    private void BombBonus(List<(int, int)> targetIndexes, int damage)
    {
        foreach (var index in targetIndexes)
        {
            if (_gridIndexes.TryGetValue(index, out Block block))
            {
                if (block.TryGetComponent(out IDamageable dam))
                {
                    if (damage == -1)
                    {
                        dam.InDestroy();
                    }
                    else
                    {
                        dam.InDamage(damage);
                    }
                }
                else
                    BlockRemove(index);
            }
        }
    }
   
    #endregion
    private void OnEnable()
    {
        BonusEvents.OnBombBonus.AddListener(BombBonus);
        BonusEvents.OnFuryBallBonus.AddListener(FuryModeBonus);
    }
}

