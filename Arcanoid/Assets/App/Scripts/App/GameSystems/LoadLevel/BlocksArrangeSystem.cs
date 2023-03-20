using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksArrangeSystem : GameSystem
{
    [Header("config")]
    public float SpawnHold = 0.02f;

    [Header("components")]
    private SpawnSystem _spawner;

    private FieldGridSystem _grid;

    private LevelData _levelData;

    private Dictionary<Vector2, Vector2> _gridTiles;

    public Dictionary<Vector2, Block> BlocksGrid { get; private set; }

    private Vector2 _startBlockSize;

    public Action<Block> OnAddNewBlock;

    public override void InitSystem()
    {
        _spawner = LevelContext.Instance.GetSystem<SpawnSystem>();

        _grid = LevelContext.Instance.GetSystem<FieldGridSystem>();

        _gridTiles = _grid.GetGrid();

        _startBlockSize = _grid.GetCurrentBlockSize();
    }

    private void Start()
    {
        GetBlocks();
    }

    public override void ReStartSystem()
    {
        GetBlocks();
    }
    public void GetBlocks()
    {
        _levelData = new LevelDataLoader().GetCurrentLevelData();

        BlocksGrid = new Dictionary<Vector2, Block>();

        //StartCoroutine(ArrangeBlocks(_levelData));

        ArrangeBlocks(_levelData);
    }

    private void  ArrangeBlocks(LevelData data)
    {
        if (data == null)
        {
            Debug.Log("Level data is null");
            //yield break;
        }

        foreach (var block in data.levelBlocks)
        {
            // yield return new WaitForSeconds(SpawnHold);

            var spawnedBlock = _spawner.pools[block.blockTag].GetObject();

            spawnedBlock.transform.position = _gridTiles[block.blockCoordinate];

            spawnedBlock.SetStartSize(_startBlockSize);

            spawnedBlock.SetGridIndex(block.blockCoordinate);

            OnAddNewBlock.Invoke(spawnedBlock);

            BlocksGrid.Add(block.blockCoordinate, spawnedBlock);
        }
    }
}
