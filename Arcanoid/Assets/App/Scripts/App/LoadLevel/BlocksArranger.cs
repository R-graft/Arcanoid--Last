using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksArranger : MonoBehaviour
{
    [Header("config")]
    public float SpawnHold = 0.02f;

    private LevelData _levelData;

    private Dictionary<BlocksList, ObjectPool<Block>> _pools;

    [HideInInspector] public int currentBlocksCount;

    private Vector2 _startBlockSize;

    public static Action OnBlocksGridFull;

    public static Action<int> OnGetBlocksCount;

    public void GetBlocks(Dictionary<(int x, int y), Vector2> gridWorldPositions, Dictionary<(int x, int y), Block> blocksGrid, Vector2 size)
    {
        _pools = SpawnSystem.Pools;

        _startBlockSize = size;

        _levelData = new LevelDataLoader().GetCurrentLevelData();

        currentBlocksCount = 0;

        StartCoroutine(ArrangeBlocks(gridWorldPositions, blocksGrid));
    }

    private Block GetPoolObjects(string tag, Vector2 position)
    {
        Enum.TryParse(tag, out BlocksList enumTag);

        var spawnObject = _pools[enumTag].Get();

        spawnObject.transform.position = position;

        return spawnObject;
    }

    private IEnumerator ArrangeBlocks(Dictionary<(int x, int y), Vector2> gridWorldPositions, Dictionary<(int x, int y),Block> blocksGrid)
    {
        _pools = SpawnSystem.Pools;

        _levelData = new LevelDataLoader().GetCurrentLevelData();

        currentBlocksCount = 0;

        if (_levelData == null)
            yield break;

        for (int i = 0; i < _levelData.blockTags.Count; i++)
        {
            yield return new WaitForSeconds(SpawnHold);

            var spawnedBlock = GetPoolObjects(_levelData.blockTags[i], gridWorldPositions[(_levelData.blockIndexX[i], _levelData.blockIndexY[i])]);

            spawnedBlock.SetStartSize(_startBlockSize);

            spawnedBlock.selfGridIndex = (_levelData.blockIndexX[i], _levelData.blockIndexY[i]);

            blocksGrid.Add(spawnedBlock.selfGridIndex, spawnedBlock);
        }

        OnGetBlocksCount(_levelData.blocksCount);

        OnBlocksGridFull?.Invoke();
    }
}
