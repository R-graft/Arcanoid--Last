using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class LevelEditor : EditorWindow
{
    private GameObject _testTile;

    private Transform _editorBlocksParent;

    public BlocksData blocksData;

    private SceneEditor _sceneEditor;

    private EditorGrid _editorGrid;

    public Dictionary<Vector2, string> currentObjects;

    public List<(string id, Sprite sprite)> allObjects;

    public int index;

    private string _saveStatus;

    private string _levelNumber;

    private string _savePath;

    private bool _isEditing;

    [MenuItem("Editors/Clear/ClearAllData", false, 0)]
    public static void ClearAllData()
    {
        ClearData();
        ClearEnergy();
    }

    [MenuItem("Editors/Clear/ClearLevelData", false,0)]
    public static void ClearData()
    {
        var saveData = Application.persistentDataPath + "/PacksData.json";

        if (File.Exists(saveData))
            File.Delete(saveData);
    }

    [MenuItem("Editors/Clear/ClearEnergy", false, 0)]
    public static void ClearEnergy()
    {
        var saveData = Application.persistentDataPath + "/EnergyData.json";

        if (File.Exists(saveData))
            File.Delete(saveData);
    }

    [MenuItem("Editors/LevelEditor")]
    public static void Init()
    {
        LevelEditor levelEditor = GetWindow<LevelEditor>("LevelEditor");

        levelEditor.Show();
    }

    private void SetBlocksDictionary()
    {
        allObjects = new List<(string id, Sprite sprite)>();

        foreach (var item in blocksData.simpleTypes)
        {
            allObjects.Add((item.type, item.sprite));
        }
        foreach (var item in blocksData.boostTypes)
        {
            allObjects.Add((item.type, item.sprite));
        }
        foreach (var item in blocksData.parentBoostTypes)
        {
            allObjects.Add((item.type, item.sprite));
        }

    }
    private void OnGUI()
    {
        if (_sceneEditor == null )
        {
            _sceneEditor = new SceneEditor();
        }

        if (!blocksData)
        {
            GUILayout.Label("EditorBlocksData");
            blocksData = (BlocksData)EditorGUILayout.ObjectField(blocksData,
                typeof(BlocksData), true);
            return;
        }

        if (blocksData && !_testTile)
        {
            GUILayout.Label("TestTilePrefab");
            _testTile = (GameObject)EditorGUILayout.ObjectField(_testTile, typeof(GameObject), true);
            return;
        }

        else
        {
            if (allObjects == null)
            {
                SetBlocksDictionary();
            }

            EditorGUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("BLOCK TYPE", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            EditorGUILayout.Space(10);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("<"))
            {
                index--;

                if (index < 0)
                {
                    index = allObjects.Count - 1;
                }
            }
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            EditorGUILayout.Space(5);
            GUILayout.Label(allObjects[index].id, EditorStyles.boldLabel);
            EditorGUILayout.Space(5);
            GUILayout.Label(allObjects[index].sprite.texture, GUILayout.Height(50), GUILayout.Width(100));

            EditorGUILayout.Space(5);
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button(">"))
            {
                index++;
                if (index > allObjects.Count - 1)
                {
                    index = 0;
                }
            }

            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            GUI.color = _isEditing ? Color.yellow : Color.white;
            if (GUILayout.Button("CreateBlocks"))
            {
                _isEditing = !_isEditing;

                if (_isEditing)
                {
                    currentObjects = new Dictionary<Vector2, string>();

                    SceneView.duringSceneGui += _sceneEditor.OnsceneGui;

                    _sceneEditor.Init(this, _editorBlocksParent);

                    if (_editorGrid == null)
                    {
                        _editorGrid = new EditorGrid(_testTile);
                    }

                    _editorGrid.CreateGrid();
                }

                if (!_isEditing)
                {
                    SceneView.duringSceneGui -= _sceneEditor.OnsceneGui;

                    _sceneEditor.Clear();
                    
                    _editorGrid.ClearGrid();

                    currentObjects.Clear();
                }
            }

            GUI.color = Color.white;

            GUILayout.Space(25);

            if (_isEditing)
            {
                GUILayout.Space(10);

                if (GUILayout.Button("Undo"))
                {
                    _sceneEditor.Undo();

                    currentObjects.Remove(currentObjects.Keys.Last());
                }

                GUILayout.Space(10);

                if (GUILayout.Button("Clear"))
                {
                    _sceneEditor.Clear();

                    currentObjects.Clear();
                }

                GUILayout.Space(50);


                if (GUILayout.Button("SaveLevel"))
                {
                    var newData = new LevelData();

                    newData.levelBlocks = new List<LevelBlock>();

                    if (int.TryParse(_levelNumber, out int currentNumber))
                    {
                        newData.levelnumber = currentNumber;

                        foreach (var Block in currentObjects)
                        {
                            var newLevelBlock = new LevelBlock();

                            newLevelBlock.blockTag = Block.Value;

                            newLevelBlock.blockCoordinate = Block.Key;

                            newData.levelBlocks.Add(newLevelBlock);
                        }

                        var directory = Application.dataPath + $"/App/Resources/Levels";

                        if (Directory.Exists(directory))
                        {
                            _savePath = Application.dataPath + $"/App/Resources/Levels/{_levelNumber}.json";

                            string savingData = JsonUtility.ToJson(newData);

                            File.WriteAllText(_savePath, savingData);

                            _saveStatus = "Level Saved";
                        }
                        else
                        {
                            _saveStatus = "Save Path is incorrect";
                        }

                    }
                    else
                    {
                        GUILayout.Space(5);
                        _saveStatus = "Level name incorrect";
                    }
                }

                GUI.color = _saveStatus == "Level Saved" ? Color.green : Color.red;
                GUILayout.Label(_saveStatus, EditorStyles.boldLabel);

                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.Label("LevelNumber");
                _levelNumber = GUILayout.TextField(_levelNumber);
                GUILayout.EndHorizontal();
                GUI.color = Color.white;

                GUILayout.Space(20);


                //if (GUILayout.Button("Load Level"))
                //{
                //    foreach (var block in currentObjects)
                //    {
                //        DestroyImmediate(block.Value.gameObject);
                //    }

                //    currentObjects.Clear();


                //    string levelData;

                //    string dataPath = Application.dataPath + $"/App/Resources/Data/Levels/{_levelNumber}.json";

                //    if (File.Exists(dataPath))
                //    {
                //        levelData = File.ReadAllText(dataPath);

                //        LevelData loadedLevel = JsonUtility.FromJson<LevelData>(levelData);

                //        var _indexes = _editorGrid;

                //        for (int i = 0; i < loadedLevel.levelBlocks.Count; i++)
                //        {
                //            var obj = editorBlocksData.editorData.First(o => o.block.blockId.ToString() == loadedLevel.levelBlocks[i]);

                //            var newblock = Instantiate(obj.block);

                //            var tilePosition = loadedLevel.blockIndexX[i].ToString() + "," + loadedLevel.blockIndexY[i].ToString();

                //            GameObject tilePos = _editorGrid._testTiles.First(p => p.name == tilePosition);

                //            newblock.name = tilePosition;

                //            newblock.transform.position = tilePos.transform.position;

                //            currentObjects.Add(newblock);
                //        }
                //    }
                //    else
                //    {
                //        _saveStatus = "level Data incorrect";
                //    }
                //}
            }
        }
    }
}
