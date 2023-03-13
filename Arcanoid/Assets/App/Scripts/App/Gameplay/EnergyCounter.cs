using System;
using UnityEngine;

public class EnergyCounter : IService
{
    private int _energy;

    [Header("config") ]
    private const int DefaultEnergy = 50;

    private const int EnergyIncreaseValue = 4;

    private const int EnergyDecreaseValue = 3;

    private const string EnergyKey = "SaveEnergyValue";

    private const string DateKey = "SavigDateValue";


    public void Init()
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
        _energy+= value;
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
            _energy = GetSavedEnergy(lastEnergy, lastDateLong);
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


    public int GetCurrentEnergy() => _energy;
    public void SetDefaultEnergy() => _energy = DefaultEnergy;
    public bool GetGameAsses() => _energy >= EnergyDecreaseValue;
}
