using System.Collections.Generic;
using UnityEngine;

public class FieldGridSystem : GameSystem
{
    [Header("config")]
    public int _rowsCount = 15;
    public int _linesCount = 15;

    public int cameraHeight = 10;

    [Header("components")]
    [SerializeField] private Camera _mCamera;

    private Vector2 _screenSize;

    private Vector2 _leftUpPosition;

    private const float _heightOffset = 0.75f;
    private const float _widthOffset = 0.98f;
    private const float _abroadOffset = 0.05f;

    private Dictionary<Vector2, Vector2> _tilePositions;

    private Vector2 _tileSize;

    public override void InitSystem()
    {
        _screenSize = new Vector2(cameraHeight * _mCamera.aspect, cameraHeight);

        _tileSize = GetBlocksSize();

        _tilePositions = CreateGrid();
    }

    public Vector2 GetCurrentBlockSize() => _tileSize;

    public Dictionary<Vector2, Vector2> GetGrid()=> _tilePositions;

    private Dictionary<Vector2, Vector2> CreateGrid()
    {
        _tilePositions = new Dictionary<Vector2, Vector2>();

        _leftUpPosition = new Vector2(-_screenSize.x * _widthOffset, _screenSize.y * _heightOffset);

        var cellLength = (-_leftUpPosition.x * 2) / _rowsCount;

        var cellHeight = cellLength / 2;

        Vector2 startPoint = (_leftUpPosition + new Vector2(cellLength / 2, -cellHeight / 2));

        var tempPos = startPoint;

        for (int i = 1; i <= _linesCount; i++)
        {
            for (int j = 1; j <= _rowsCount; j++)
            {
                _tilePositions.Add(new Vector2(i, j), tempPos);

                tempPos.x += cellLength;
            }

            tempPos.y -= cellHeight;

            tempPos.x = startPoint.x; 
        }
        return _tilePositions;
    }

    private Vector2 GetBlocksSize()
    {
        float widthBlocksSpace = _screenSize.x - _abroadOffset * (_rowsCount - 1);

        float blockWidth = (widthBlocksSpace / _rowsCount) * 2;

        float blockHeight = blockWidth * 0.97f;

        return new Vector2(blockWidth, blockHeight);
    }
}

public struct Tile
{
    public Vector2 gridPosition;

    public Vector2 worldPosition;
}
