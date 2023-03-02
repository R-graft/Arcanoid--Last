using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EditorBlocksData", menuName = "Data/newEditorBlocksData")]
public class EditorBlocksData : ScriptableObject
{
    public EditorBlock[] editorData;
}

[System.Serializable]
public class EditorBlock
{
    public Block block;

    public Texture2D blockTexture;
}


