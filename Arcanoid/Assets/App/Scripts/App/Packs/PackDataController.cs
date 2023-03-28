using UnityEngine;

public class PackDataController: MonoBehaviour, IService
{
    [Header("config")]
    private const string PackDataDirectory = "/PacksData.json";

    [Header("components")]
    [SerializeField] private PacksData _packsData;

    private Pack _currentPack;

    private Pack[] _packsModels;

    private GameProgress _currentProgressData;

    private int _currentLevel;

    private int _currentPackIndex;

    public void InitService()
    {
        Load();
    }

    public void Load()
    {
        _packsModels = _packsData.packsModels;

        _currentProgressData = new DataReader<GameProgress>(PackDataDirectory).ReadFileFromSystem();

        if (_currentProgressData == null)
        {
            SetPackDataToDefault();
        }

        else
        {
            _currentLevel = _currentProgressData.currentLevel;

            _currentPackIndex = _currentProgressData.currentPackIndex;

            _currentPack = _packsModels[_currentPackIndex];
        }

        Save();
    }

    public void Save()
    {
        _currentProgressData.currentLevel = _currentLevel;

        _currentProgressData.currentPackIndex = _currentPackIndex;

        new DataWriter<GameProgress>(_currentProgressData, PackDataDirectory).SaveFileToSystem();
    }

    public void SetLevelFrowView(int packIndex)
    {
        if (packIndex >= 0 && packIndex <= _packsModels.Length)
        {
            _currentPackIndex = packIndex;

            _currentPack = _packsModels[packIndex];

            if (_currentPack.isEnded)
            {
                _currentPack.EndedLevel = 0;
                _currentPack.isEnded = false;
                _currentLevel = _currentPack.startLevel;
            }

            else
            {
                _currentLevel = _currentPack.startLevel + _currentPack.EndedLevel;
            }
        }

        Save();
    }

    public void LevelPass()
    {
        _currentLevel++;

        if (_currentLevel > _currentPack.finishLevel)
        {
            if (_currentPackIndex + 1 >= _packsModels.Length)
            {
                SetPackDataToDefault();

                return;
            }

            _currentPackIndex++;

            _currentPack.EndedLevel++;

            _currentPack.isEnded = true;

            _currentPack = _packsModels[_currentPackIndex];

            _currentPack.isOpen = true;
        }
        else
        {
            _currentPack.EndedLevel++;
        }

        Save();
    }
    public Pack GetCurrentPack() => _currentPack;

    public int GetCurrentPackLevel() => _currentPack.EndedLevel;
    public int GetCurrentPackLastLevel() => _currentPack.finishLevel - _currentPack.startLevel +1;
    public int GetGlobalLevel() => _currentLevel;

    
    public void SetPackDataToDefault()
	{
        ClearPacks();

        _currentProgressData = new GameProgress();

        _currentProgressData.currentPackIndex = 0;

        _currentProgressData.currentLevel = 1;

        _currentPack = _packsModels[_currentProgressData.currentPackIndex];

        _currentLevel = _currentProgressData.currentLevel;

        _packsModels[0].isOpen = true;
    }

    private void ClearPacks()
    {
        foreach (var model in _packsModels)
        {
            model.isEnded= false;
            model.isOpen= false;
            model.EndedLevel = 0;
        }
    }
}
[System.Serializable]
public class GameProgress
{
    public int currentLevel;

    public int currentPackIndex;
}
