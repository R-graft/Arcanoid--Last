using System.Collections.Generic;
using UnityEngine;

public class FieldGridSystem : MonoBehaviour
{
    [Header("config")]
    public int _rowsCount = 7;
    public int _linesCount = 7;

    public int cameraHeight = 10;

    [Header("components")]
    [SerializeField] private Camera _mCamera;

    private Vector2 _screenSize;

    private Vector2 _leftUpPosition;

    private const float _heightOffset = 0.75f;
    private const float _widthOffset = 0.98f;
    private const float _abroadOffset = 0.05f;

    public Dictionary<(int,int), Vector2> gridPositions = new Dictionary<(int, int), Vector2>();

    [HideInInspector] public Vector2 blockSize;

    public void Init()
    {
        _screenSize = new Vector2(cameraHeight * _mCamera.aspect, cameraHeight);

        blockSize = GetBlocksSize();

        gridPositions = CreateGrid();
    }
    public Dictionary<(int, int), Vector2> CreateGrid()
    {
        _leftUpPosition = new Vector2(-_screenSize.x * _widthOffset, _screenSize.y * _heightOffset);

        var cellLength = (-_leftUpPosition.x * 2) / _rowsCount;

        var cellHeight = cellLength / 2;

        Vector2 startPoint = (_leftUpPosition + new Vector2(cellLength / 2, -cellHeight / 2));

        var tempPos = startPoint;

        for (int i = 1; i <= _linesCount; i++)
        {
            for (int j = 1; j <= _rowsCount; j++)
            {
                gridPositions.Add((i, j), tempPos);

                tempPos.x += cellLength;
            }

            tempPos.y -= cellHeight;

            tempPos.x = startPoint.x; 
        }

        return gridPositions;
    }

    public Vector2 GetBlocksSize()
    {
        float widthBlocksSpace = _screenSize.x - _abroadOffset * (_rowsCount - 1);

        float blockWidth = (widthBlocksSpace / _rowsCount) * 2;

        float blockHeight = blockWidth / 2;

        return new Vector2(blockWidth, blockHeight);
    }
}
