using System;
using System.Collections;
using UnityEngine;

public class EnergyBarCounter : MonoBehaviour
{
    [SerializeField] private EnergyBarView _barView;

    private EnergyCounter _energy;

    private int _currentEnergy;

    private int _maxEnergy;

    private int _currentRemainingTime;

    private const int RequestTime = 1;

    private const int EnergyRecoveryTime = 70;

    private void OnEnable()
    {
        _energy = ProjectContext.Instance.GetService<EnergyCounter>();

        _barView.Init(EnergyRecoveryTime);

        GetEnergyValues();

        _barView.UpdateBar(_currentEnergy, _maxEnergy, _currentRemainingTime);

        StartCoroutine(EnergyTimeCounter());
    }

    private void GetEnergyValues()
    {
        _energy.Save();

        var (current, max) = _energy.GetCurrentEnergy();

        _currentEnergy = current;
        _maxEnergy = max;

        _currentRemainingTime = _energy.GetRemainingTime();
    }

    public void IncreaseEffect(Action hide)
    {
        _barView.UpdateBar(_currentEnergy, _maxEnergy, _currentRemainingTime);

        GetEnergyValues();

        _barView.IncreaseEffect(hide);
    }

    public void DecreaseEffect(Action hide)
    {
        _barView.DecreaseEffect(hide);

        GetEnergyValues();

        _barView.UpdateBar(_currentEnergy, _maxEnergy, _currentRemainingTime);
    }

    public void DisableEffect()
    {
        _barView.DisableEffect();
    }
    private IEnumerator EnergyTimeCounter()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(RequestTime);

            GetEnergyValues();

            _barView.UpdateBar(_currentEnergy, _maxEnergy, _currentRemainingTime);
        }
    }
}
