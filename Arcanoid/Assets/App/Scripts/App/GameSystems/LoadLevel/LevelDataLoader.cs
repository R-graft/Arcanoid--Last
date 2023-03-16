public class LevelDataLoader
{
    private PackDataController _packData;

    private int _currentLevel;

    public LevelData GetCurrentLevelData()
    {
        _packData = ProjectContext.Instance.GetService<PackDataController>();

        _currentLevel = _packData.GetGlobalLevel();

        string _levelsFilesPath = $"Levels/{_currentLevel}";

        return new DataReader<LevelData>(_levelsFilesPath).ReadFileFromResources();
    }
}
