public class LevelDataLoader
{
    private PackDataController _packData;

    private int _currentLevel;

    public LevelData GetCurrentLevelData()
    {
        _packData = ProjectContext.Instance.GetService<PackDataController>();

        _currentLevel = _packData.GetGlobalLevel();

        string _levelsFilesPath = $"Levels/{_currentLevel}";

        var newlevelFile = new DataReader<LevelData>(_levelsFilesPath).ReadFileFromResources();

        if (newlevelFile == default)
        {
            ScenesManager.Instance.LoadScene(1);

            return new DataReader<LevelData>($"Levels/{1}").ReadFileFromResources();
        }
        else
        {
            return newlevelFile;
        }
    }
}
