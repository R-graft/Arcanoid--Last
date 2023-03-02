using UnityEngine;
using UnityEditor;

public class SceneEditor : EditorWindow
{
    private LevelEditor _lEditor;

    private Transform _parent;

    public void Init(LevelEditor levelEditor, Transform parent)
    {
        _lEditor = levelEditor;

        _parent = parent;
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
        Block newBlock = Instantiate(_lEditor.editorBlocksData.editorData[_lEditor.index].block, _parent);

        newBlock.transform.position = collider.transform.position;

        newBlock.name = collider.name;

        _lEditor.currentObjects.Add((newBlock));
    }
}
