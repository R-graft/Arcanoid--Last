using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _energyValue;
    [SerializeField] private TextMeshProUGUI _maxEnergyValue;

    [SerializeField] private Image _increaseEffect;
    [SerializeField] private Image _decreaseEffect;

    [SerializeField] private Image _disableEffect;

    [SerializeField] private Slider _energySlide;

    [SerializeField] private TextMeshProUGUI _bigValue;

    [SerializeField] private TextMeshProUGUI _littleValue;

    private AnimateHandler _animator;

    private int _energyRecoveryTime;

    private TimeSpan timer;
    public void Init(int recoveryTime)
    {
        _animator ??= ProjectContext.Instance.GetService<AnimateHandler>();

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

    public void IncreaseEffect(Action hide)
    {
        _animator.AnimateEnergyChange(_increaseEffect, hide);
    }

    public void DecreaseEffect(Action hide)
    {
        _animator.AnimateEnergyChange(_decreaseEffect, hide);
    }

    public void DisableEffect()
    {
        _animator.AnimateEnergyChange(_disableEffect, null);
    }
}
