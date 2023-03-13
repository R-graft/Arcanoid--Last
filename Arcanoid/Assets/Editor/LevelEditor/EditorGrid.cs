using System.Collections.Generic;
using UnityEngine;

public class EditorGrid : MonoBehaviour
{
    private GameObject _tile;

    private GameObject _tileParent;

    private Vector2 _leftUpPosition;

    private Vector2 _screenSize;

    private const int _rowsCount = 7;

    private const int _linesCount = 7;

    private const float _heightOffset = 0.75f;

    private const float _widthOffset = 0.98f;

    private const float _abroadOffset = 0.05f;

    public  List<GameObject> _testTiles;
    public EditorGrid(GameObject testTile)
    {
        _tile = testTile;
    }
    public void CreateGrid()
    {
        _tileParent = new GameObject();

        _screenSize = GetScreen();

        _testTiles = new List<GameObject>();

        _leftUpPosition = new Vector2(-_screenSize.x * _widthOffset, _screenSize.y * _heightOffset);

        print(_leftUpPosition);

        var cellLength = (-_leftUpPosition.x * 2) / _rowsCount;

        var cellHeight = cellLength / 2;

        Vector2 startPoint = (_leftUpPosition + new Vector2(cellLength / 2, -cellHeight / 2));

        var tempPos = startPoint;

        for (int i = 0; i < _linesCount; i++)
        {
            for (int j = 0; j < _rowsCount; j++)
            {
                var newTile = Instantiate(_tile, tempPos, Quaternion.identity, _tileParent.transform);

                ResizeBlock(newTile);

                newTile.name = $"{i + 1},{j + 1}";

                _testTiles.Add(newTile);

                tempPos.x += cellLength;
            }

            tempPos.y -= cellHeight;

            tempPos.x = startPoint.x;
        }
    }

    public void ClearGrid()
    {
        DestroyImmediate(_tileParent);
    }
    private Vector2 GetScreen()
    {
        var screenHeight = 10;

        var screenWidth = screenHeight * Camera.main.aspect;

        return new Vector2(screenWidth, screenHeight);
    }
    private void ResizeBlock(GameObject tile)
    {
        float widthBlocksSpace = _screenSize.x- _abroadOffset * (_rowsCount - 1);

        float blockWidth = (widthBlocksSpace / _rowsCount) * 2;

        float blockHeight = blockWidth / 2;

        tile.transform.localScale = new Vector2(blockWidth, blockHeight);
    }
}
