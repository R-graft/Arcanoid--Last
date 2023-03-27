using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _energyValue;
    [SerializeField] private TextMeshProUGUI _maxEnergyValue;

    [SerializeField] private Slider _energySlide;

    [SerializeField] private TextMeshProUGUI _bigValue;

    [SerializeField] private TextMeshProUGUI _littleValue;

    private int _energyRecoveryTime;

    private TimeSpan timer;
    public void Init(int recoveryTime)
    {
        _energyRecoveryTime = recoveryTime;

        timer = new TimeSpan().Add(TimeSpan.FromSeconds(_energyRecoveryTime));
    }
    public void UpdateBar(int current, int max, int remaining)
    {
        _energyValue.text = current.ToString();

        _maxEnergyValue.text = max.ToString();

        _energySlide.value = (float)current / (float)max;

        TimeSpan time = TimeSpan.FromSeconds(remaining);

        _bigValue.text = (timer - time).ToString(@"mm\:ss");
    }
}
