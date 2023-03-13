using UnityEngine;

[CreateAssetMenu(fileName = "EditorBlocksData", menuName = "Data/newEditorBlocksData")]
public class EditorBlocksData : ScriptableObject
{
    public EditorBlock[] editorData;
}

[System.Serializable]
public class EditorBlock
{
    public string id;

    public Sprite blockTexture;
}


