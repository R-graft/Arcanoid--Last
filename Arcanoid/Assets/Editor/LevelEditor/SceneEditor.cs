using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class SceneEditor : EditorWindow
{
    private LevelEditor _lEditor;

    private Transform _parent;

    private List<GameObject> editedTiles;

    public void Init(LevelEditor levelEditor, Transform parent)
    {
        _lEditor = levelEditor;

        _parent = parent;

        editedTiles = new List<GameObject>();
    }

    public void OnsceneGui(SceneView sceneView)
    {
        Event current = Event.current;

        if (current.type == EventType.MouseDown)
        {
            Vector2 mousePoint = sceneView.camera.ScreenToWorldPoint(new Vector3(current.mousePosition.x,
                sceneView.camera.pixelHeight - current.mousePosition.y, sceneView.camera.nearClipPlane));

            Collider2D collider = Physics2D.OverlapCircle(mousePoint, 0.01f);

            if (collider && collider.CompareTag("testTile"))
            {
                CreateCurrentBlock(collider);
            }
        }
    }

    private void CreateCurrentBlock(Collider2D collider)
    {
        editedTiles.Add(collider.gameObject);

        var tileSprite = collider.GetComponent<SpriteRenderer>();

        tileSprite.sprite = _lEditor.allObjects[_lEditor.index].sprite;

        var pos = collider.gameObject.name.Split(',');

        var newIndex = new Vector2(int.Parse(pos[0]), int.Parse(pos[1]));

        _lEditor.currentObjects.Add(newIndex, _lEditor.allObjects[_lEditor.index].id);
    }

    public void Clear()
    {
        for (int i = 0; i < editedTiles.Count; i++)
        {
            editedTiles[i].GetComponent<SpriteRenderer>().sprite = default;

            editedTiles.RemoveAt(i);
        }
    }

    public void Undo()
    {
        editedTiles[editedTiles.Count - 1].GetComponent<SpriteRenderer>().sprite = null;

        editedTiles.RemoveAt(editedTiles.Count - 1);
    }
}
