using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnergyCounter : IService
{
    private int _energy;

    [Header("config") ]
    private const int DefaultEnergy = 25;

    private const int MaxEnergyValue = 100;

    private const int EnergyIncreaseValue = 4;

    private const int EnergyDecreaseValue = 3;

    private const string EnergyKey = "SaveEnergyValue";

    private const string DateKey = "SavigDateValue";

    private const string MinutesKey = "RemainingMinutes";


    public void InitService()
    {
        Load();
    }

    public void Load()
    {
        int loadedEnergy = GetSavedEnergy();

        _energy = loadedEnergy > MaxEnergyValue ? MaxEnergyValue : loadedEnergy;

        Save();
    }
    private void Save()
    {
        string lastData = DateTime.Now.ToFileTime().ToString();

        PlayerPrefs.SetString(DateKey, lastData);

        PlayerPrefs.SetInt(EnergyKey, _energy);
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

        Save();
    }

    private int GetSavedEnergy()
    {
        if (!PlayerPrefs.HasKey(EnergyKey))
        {
            SetDefaultEnergy();

            return _energy;
        }

        int lastEnergy = PlayerPrefs.GetInt(EnergyKey);

        string lastDateStr = PlayerPrefs.GetString(DateKey);

        if (long.TryParse(lastDateStr, out long lastDateLong))
        {
            var savingDate = DateTime.FromFileTime(lastDateLong);

            int loadedMinutesValue = DateTime.Now.Subtract(savingDate).Minutes;

            int savedMinutes = PlayerPrefs.GetInt(MinutesKey);

            int loadedMinutes = loadedMinutesValue + savedMinutes;

            lastEnergy += loadedMinutes / 60;

            PlayerPrefs.SetInt(MinutesKey, loadedMinutes % 60);

        }

        return lastEnergy;
    }

    public void LoadLevel() => DecreaseEnergy(EnergyDecreaseValue);
    public void LevelPass() => IncreaseEnergy(EnergyIncreaseValue);

    public (int current, int max) GetCurrentEnergy() => (_energy, MaxEnergyValue);

    public void SetDefaultEnergy()
    {
        PlayerPrefs.SetString(DateKey, DateTime.Now.ToString());

        PlayerPrefs.SetString(EnergyKey, DateTime.Now.ToString());

        PlayerPrefs.SetInt(MinutesKey, 0);

        _energy = DefaultEnergy;
    } 

    public bool GetGameAsses() => _energy >= EnergyDecreaseValue;
}
