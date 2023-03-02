using System.Collections.Generic;
using UnityEngine;

public class FieldGrid
{
    private Vector2 _leftUpPosition;

    private int _rowsCount = 10;
    private int _linesCount = 10;

    private const float _heightOffset = 0.66f;
    private const float _widthOffset = 0.5f;
    private const float _abroadOffset = 0.025f;

    public Dictionary<(int,int), Vector2> gridPositions = new Dictionary<(int, int), Vector2>();

    public FieldGrid(int rowsCount, int linesCount)
    {
        _rowsCount = rowsCount;
        _linesCount = linesCount;
    }
    public Dictionary<(int, int), Vector2> CreateGrid()
    {
        _leftUpPosition = new Vector2(-ScreenSizeHandler.Instance.screenWidth + _widthOffset, ScreenSizeHandler.Instance.screenHeight * _heightOffset);

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
        float widthBlocksSpace = ScreenSizeHandler.Instance.screenWidth - (_widthOffset * 2) + _abroadOffset * (_rowsCount - 1);

        float blockWidth = (widthBlocksSpace / _rowsCount) * 2;

        float blockHeight = blockWidth / 2;

        return new Vector2(blockWidth, blockHeight);
    }
}
