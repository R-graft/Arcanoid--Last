using System;
using UnityEngine;

public class GameProgressController : Singleton<GameProgressController> 
{
    [SerializeField] private PacksData _packsDataObject;

    private GameProgressData CurrentProgressData;

    public PackDataController PacksController { get; private set; }

    public EnergyCounter EnergyCounter { get; private set; }

    public int Level { get; private set; }

    public bool GameAccess { get { return EnergyCounter.SetGameAsses(); } }

    private readonly string gameProgessDataFile = "/GameProgress.json";

    public void Init()
    {
        SingleInit();

        PacksController = new PackDataController(_packsDataObject.packsModels);

        EnergyCounter = new EnergyCounter();

        Load();
    }
    public void PassLevel()
    {
        Level++;

        PacksController.LevelPass(Level);

        EnergyCounter.LevelPass();

        Save();
    }
    public void LoadLevel()
    {
        EnergyCounter.LoadLevel();

        Save();
    }
    public void SetEnergy(int value, bool isIncrease)
    {
        EnergyCounter.ChangeEnergyValue(value, isIncrease);

        Save();
    }

    public void SetDataFromVeiw(int packIndex)
    {
        PacksController.SetLevelFrowView(packIndex);

        Level = PacksController.GetGlobalLevel();

        Save();
    }

    private void Load()
    {
        CurrentProgressData = new DataReader<GameProgressData>(gameProgessDataFile).ReadFileFromSystem();

        if (CurrentProgressData == null)
        {
            SetDefaultProgress();

            return;
        }

        Level = CurrentProgressData.currentLevel;

        EnergyCounter.Load(CurrentProgressData.currentEnergy, CurrentProgressData.lastData);

        PacksController.Load(CurrentProgressData.packsDatas, Level);

        Save();
    }

    private void Save()
    {
        CurrentProgressData.currentLevel = Level;

        CurrentProgressData.currentEnergy = EnergyCounter.GetEnergy();

        PacksController.Save(CurrentProgressData.packsDatas);

        CurrentProgressData.lastData = DateTime.Now.ToFileTime();

        DataWriter<GameProgressData> currentWriter =
            new DataWriter<GameProgressData>(CurrentProgressData, gameProgessDataFile);

        currentWriter.SaveFileToSystem();
    }

    private void SetDefaultProgress()
    {
        CurrentProgressData = new GameProgressData();

        EnergyCounter.SetDefaultEnergy();

        Level = 1;

        PacksController.SetPackDataToDefault(CurrentProgressData);

        Save();
    }

    private void OnApplicationPause()
    {
#if PLATFORM_ANDROID
        PlayerPrefs.DeleteKey("FirstIn");
#endif
    }
}

[System.Serializable]
public class GameProgressData
{
    public int currentLevel;

    public int currentEnergy;

    public long lastData;

    public PackSaveData[] packsDatas;
}
