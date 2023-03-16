using System.Collections.Generic;
using UnityEngine;

public class BlocksArrangeSystem : GameSystem
{
    [Header("config")]
    public float SpawnHold = 0.02f;

    [Header("components")]
    private SpawnSystem _spawner;

    private FieldGridSystem _grid;

    private BlocksSystem _blocks;

    private LevelData _levelData;

    private Dictionary<Vector2, Vector2> _gridTiles;

    private Vector2 _startBlockSize;

    public override void InitSystem()
    {
        _spawner = LevelContext.Instance.GetSystem<SpawnSystem>();

        _grid = LevelContext.Instance.GetSystem<FieldGridSystem>();

        _blocks = LevelContext.Instance.GetSystem<BlocksSystem>();

        _gridTiles = _grid.GetGrid();

        _startBlockSize = _grid.GetCurrentBlockSize();

        GetBlocks();
    }

    public override void StartSystem()
    {

    }

    public override void ReStartSystem()
    {
        _blocks.ClearBlocks();

        GetBlocks();
    }
    public void GetBlocks()
    {
        _levelData = new LevelDataLoader().GetCurrentLevelData();

        ArrangeBlocks(_levelData);
    }

    private void ArrangeBlocks(LevelData data)
    {
        if (data == null)
        {
            Debug.Log("Level data is null");
            //yield break;
        }

        foreach (var block in data.levelBlocks)
        {
            //yield return new WaitForSeconds(SpawnHold);

            var spawnedBlock = _spawner.pools[block.blockTag].GetObject();

            spawnedBlock.transform.position = _gridTiles[block.blockCoordinate];

            spawnedBlock.SetStartSize(_startBlockSize);

            spawnedBlock.SetGridIndex(block.blockCoordinate);

            if (!spawnedBlock.nonDamageable)
            {
                _blocks.AddBlock(spawnedBlock);
            }
        }

        //yield break;
    }
}
