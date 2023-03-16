using System;
using UnityEngine;

public class EnergyCounter : IService
{
    private int _energy;

    [Header("config") ]
    private const int DefaultEnergy = 50;

    private const int MaxEnergyValue = 100;

    private const int EnergyIncreaseValue = 4;

    private const int EnergyDecreaseValue = 3;

    private const string EnergyKey = "SaveEnergyValue";

    private const string DateKey = "SavigDateValue";


    public void InitService()
    {
        Load();
    }

    public void SetEnergy(int value)
    {
        if (value < 0)
        {
            return;
        }

        _energy = value;
    }

    public void IncreaseEnergy(int value)
    {
        _energy = _energy + value > MaxEnergyValue ? MaxEnergyValue : _energy + value;

        Save();
    }

    public void DecreaseEnergy(int value)
    {
        if (_energy - value < 0)
        {
            return;
        }

        _energy -= value;
    }

    public void Load()
    {
        int lastEnergy = PlayerPrefs.GetInt(EnergyKey);

        string lastDateStr = PlayerPrefs.GetString(DateKey);

        if (long.TryParse(lastDateStr, out long lastDateLong))
        {
            int loadedEnergy = GetSavedEnergy(lastEnergy, lastDateLong);

            _energy = loadedEnergy > MaxEnergyValue? MaxEnergyValue : loadedEnergy;
        }
        else
        {
            SetDefaultEnergy();
        }

        Save();
    }
    public void Save()
    {
        string lastData = DateTime.Now.ToFileTime().ToString();

        PlayerPrefs.SetString(DateKey, lastData);

        PlayerPrefs.SetInt(EnergyKey, _energy);
    }

    private int GetSavedEnergy(int lastEnergyValue, long lastSavingDate)
    {
        var savingDate = DateTime.FromFileTime(lastSavingDate);

        lastEnergyValue += DateTime.Now.Subtract(savingDate).Hours;

        return _energy = lastEnergyValue;
    }

    public void LoadLevel() => DecreaseEnergy(EnergyDecreaseValue);
    public void LevelPass() => IncreaseEnergy(EnergyIncreaseValue);


    public (int current, int max) GetCurrentEnergy() => (_energy, MaxEnergyValue);
    public void SetDefaultEnergy()
    {
        PlayerPrefs.SetString(DateKey, DateTime.Now.ToString());

        _energy = DefaultEnergy;
    } 
    public bool GetGameAsses() => _energy >= EnergyDecreaseValue;
}
