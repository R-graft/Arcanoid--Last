using UnityEngine;

public class PackDataController: MonoBehaviour, IService
{
    [Header("config")]
    private const string PackDataDirectory = "/PacksData.json";

    private const int _defaultValue = 0;

    [Header("components")]
    [SerializeField] private PacksData _packsData;

    private Pack _currentPack;

    private Pack[] _packsModels;

    private GameProgress CurrentProgressData;

    private int _currentLevel;

    public void InitService()
    {
        Load();
    }

    public void Load()
    {
        _packsModels = _packsData.packsModels;

        CurrentProgressData = new DataReader<GameProgress>(PackDataDirectory).ReadFileFromSystem();

        if (CurrentProgressData == null)
        {
            SetPackDataToDefault();
        }

        _currentLevel = CurrentProgressData.currentLevel;

        ToPacks(CurrentProgressData.packsDatas, _currentLevel);

        Save();
    }

    public void Save()
    {
        CurrentProgressData.currentLevel = _currentLevel;

        DataWriter<GameProgress> currentWriter =
            new DataWriter<GameProgress>(CurrentProgressData, PackDataDirectory);

        currentWriter.SaveFileToSystem();
    }

    private void ToPacks(PackSaveData[] data, int level)
    {
        for (int i = 0; i < _packsModels.Length; i++)
        {
            _packsModels[i].EndedLevel = data[i].EndedLevel;

            _packsModels[i].isEnded = data[i].packIsended;

            _packsModels[i].isOpen = data[i].packIsOpen;

            if (_packsModels[i].startLevel <= level && _packsModels[i].finishLevel >= level)
                _currentPack = _packsModels[i];
        }
    }
    private void FromPacks(PackSaveData[] data, int level)
    {
        for (int i = 0; i < _packsModels.Length; i++)
        {
            data[i].packIndex = i;

            data[i].EndedLevel = _packsModels[i].EndedLevel;

            data[i].packIsended = _packsModels[i].isEnded;

            data[i].packIsOpen = _packsModels[i].isOpen;

            if (_packsModels[i].startLevel <= level && _packsModels[i].finishLevel >= level)
                _currentPack = _packsModels[i];
        }
    }


    public void SetLevelFrowView(int packIndex)
    {
        if (packIndex >= 0 && packIndex <= _packsModels.Length)
        {
            _currentPack = _packsModels[packIndex];

            if (_currentPack.isEnded)
            {
                _currentPack.EndedLevel = _defaultValue;

                _currentPack.isEnded = false;

                _currentLevel = _currentPack.startLevel;
            }
        }
        FromPacks(CurrentProgressData.packsDatas, _currentLevel);

        Save();
    }
    public Pack GetCurrentPack() => _currentPack;

    public int GetCurrentPackLevel() => _currentPack.EndedLevel;
    public int GetCurrentPackLastLevel() => _currentPack.finishLevel - _currentPack.startLevel+1;
    public int GetGlobalLevel() => _currentLevel;

    public void LevelPass()
    {
        _currentLevel++;

        if (_currentLevel > _currentPack.finishLevel)
        {
            _currentPack.EndedLevel++;

            _currentPack.isEnded = true;

            _currentPack = _packsModels[_currentPack.packIndex + 1];

            _currentPack.isOpen = true;
        }
        else
        {
            _currentPack.EndedLevel++;
        }

        FromPacks(CurrentProgressData.packsDatas, _currentLevel);

        Save();
    }
    public void SetPackDataToDefault()
	{
        CurrentProgressData = new GameProgress();

        CurrentProgressData.currentLevel = _defaultValue;

        CurrentProgressData.packsDatas = new PackSaveData[_packsModels.Length];

        for (int i = 0; i < CurrentProgressData.packsDatas.Length; i++)
        {
            CurrentProgressData.packsDatas[i] = new PackSaveData();

            CurrentProgressData.packsDatas[i].packIndex = i;
        }

        foreach (var item in _packsModels)
        {
            item.EndedLevel = _defaultValue;
            item.isOpen = false;
            item.isEnded = false;
        }

        CurrentProgressData.packsDatas[0].packIsOpen = true;

        _currentLevel = 1;

        ToPacks(CurrentProgressData.packsDatas, _currentLevel);

        Save();
    }
}
[System.Serializable]
public class GameProgress
{
    public int currentLevel;

    public PackSaveData[] packsDatas;
}
[System.Serializable]
public class PackSaveData
{
    public int packIndex;

    public bool packIsOpen;

    public bool packIsended;

    public int EndedLevel;
}


