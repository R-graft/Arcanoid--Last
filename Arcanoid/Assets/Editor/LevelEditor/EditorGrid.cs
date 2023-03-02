using System.Collections.Generic;
using UnityEngine;

public class EditorGrid : MonoBehaviour
{
    private GameObject _tile;

    private Vector2 _leftUpPosition;

    private const int _rowsCount = 10;

    private const int _linesCount = 10;

    private const float _heightOffset = 0.81f;

    private const float _widthOffset = 0.1f;

    public  List<GameObject> _testTiles;
    public EditorGrid(GameObject testTile)
    {
        _tile = testTile;
    }
    public void CreateGrid()
    {
        _testTiles = new List<GameObject> ();

        _leftUpPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * _widthOffset, (Screen.height * _heightOffset)));

        var cellLength = (-_leftUpPosition.x * 2) / _rowsCount;

        var cellHeight = cellLength / 2;

        Vector2 startPoint = (_leftUpPosition + new Vector2(cellLength / 2, -cellHeight / 2));

        var tempPos = startPoint;

        for (int i = 0; i < _linesCount; i++)
        {
            for (int j = 0; j < _rowsCount; j++)
            {
                var newTile = Instantiate(_tile, tempPos, Quaternion.identity);

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
        foreach (var item in _testTiles)
        {
            DestroyImmediate(item);
        }
    }
}
