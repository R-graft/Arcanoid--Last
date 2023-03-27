using System;
using UnityEngine;

public class EnergyCounter : IService
{
    private int _energy;

    [Header("config") ]
    private const int DefaultEnergy = 75;

    private const int MaxEnergyValue = 100;

    private const int EnergyIncreaseValue = 4;

    private const int EnergyDecreaseValue = 3;

    private const int EnergyRecoveryTime = 70;

    private const string FileDataDirectory = "/EnergyData.json";

    private EnergyData _currentData;

    public void InitService()
    {
        Load();
    }

    public void Load()
    {
        _currentData = new DataReader<EnergyData>(FileDataDirectory).ReadFileFromSystem();

        if (_currentData == null)
        {
            SetDefaultEnergy();
        }

        else
        {
            int lastEnergy = _currentData.energyValue;

            int timeGap = GetTimeGap(_currentData);

            _energy = lastEnergy + timeGap;

            _energy = _energy > MaxEnergyValue ? MaxEnergyValue : _energy;
        }

        Save();
    }
    public void Save()
    {
        int timeGap = GetTimeGap(_currentData);

        _energy += timeGap;

        _energy = _energy > MaxEnergyValue ? MaxEnergyValue : _energy;

        _currentData.energyValue = _energy;

        _currentData.lastDate = DateTime.Now.ToFileTime();

        new DataWriter<EnergyData>(_currentData, FileDataDirectory).SaveFileToSystem();
    }

    private int GetTimeGap(EnergyData data)
    {
        var fileTime = DateTime.FromFileTime(data.lastDate);

        var timeGap = DateTime.Now.Subtract(fileTime).Seconds;

        timeGap += data.remainingSeconds;

        data.remainingSeconds = timeGap % EnergyRecoveryTime;

        timeGap /= EnergyRecoveryTime;

        return timeGap;
    }

    public void IncreaseEnergy(int value)
    {
        _energy += value;

        Save();
    }

    public void DecreaseEnergy(int value)
    {
        if (_energy - value < 0)
        {
            return;
        }

        _energy -= value;

        Save();
    }

    public void LoadLevel() => DecreaseEnergy(EnergyDecreaseValue);
    public void LevelPass() => IncreaseEnergy(EnergyIncreaseValue);

    public (int current, int max) GetCurrentEnergy() => (_energy, MaxEnergyValue);

    public int GetRemainingTime() => _currentData.remainingSeconds;

    public void SetDefaultEnergy()
    {
        _currentData = new EnergyData(_energy, DateTime.Now.ToFileTime());

        _energy = DefaultEnergy;
    } 

    public bool GetGameAsses() => _energy >= EnergyDecreaseValue;
}

[System.Serializable]
public class EnergyData
{
    public int energyValue;
    public long lastDate;
    public int remainingSeconds;

    public EnergyData(int energyValue, long lastDate)
    {
        this.energyValue = energyValue;
        this.lastDate = lastDate;
    }
}