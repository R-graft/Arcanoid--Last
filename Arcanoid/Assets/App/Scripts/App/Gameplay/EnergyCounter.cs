using System;

public class EnergyCounter
{
    private int Energy;

    private const int DefaultEnergy = 50;

    private const int EnergyIncreaseValue = 4;

    private const int EnergyDecreaseValue = 3;

    public int GetEnergy() => Energy;

    public void SetEnergy(int value) => Energy = value;

    public void LoadLevel() => ChangeEnergyValue(EnergyDecreaseValue, false);

    public void LevelPass() => ChangeEnergyValue(EnergyIncreaseValue, true);

    public void ChangeEnergyValue(int value, bool isIncrease)
    {
        if (isIncrease)
        {
            Energy += value;
        }
        else
        {
            if (Energy - value < 0)
            {
                return;
            }
            Energy -= value;
        }
    }

    public void Load(int lastEnergyValue, long lastSavingDate)
    {
        var savingDate = DateTime.FromFileTime(lastSavingDate);

        lastEnergyValue += DateTime.Now.Subtract(savingDate).Hours;

        Energy = lastEnergyValue;
    }
    public void SetDefaultEnergy() => Energy = DefaultEnergy;

    public bool SetGameAsses() => Energy >= EnergyDecreaseValue;
}
