using UnityEngine;

public class LevelDataLoader
{
    private int _currentLevel;

    public LevelData GetCurrentLevelData()
    {
        if (GameProgressController.Instance != null)
        {
            _currentLevel = GameProgressController.Instance.Level;

            string _levelsFilesPath = $"Data/Levels/{_currentLevel}";

            return new DataReader<LevelData>(_levelsFilesPath).ReadFileFromResources();
        }

        Debug.Log("Game progress not exist");

        return null;
    }
}
