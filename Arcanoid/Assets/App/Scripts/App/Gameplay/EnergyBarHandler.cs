using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _energyValue;
    [SerializeField] private TextMeshProUGUI _maxEnergyValue;

    [SerializeField] private Slider _energySlide;

    [SerializeField] private TextMeshProUGUI _hours;

    [SerializeField] private TextMeshProUGUI _minutes;

    private EnergyCounter _energy;

    private const string MinutesKey = "RemainingMinutes";

    private void Start()
    {
        _energy = ProjectContext.Instance.GetService<EnergyCounter>();

        UpdateBar();

        StartCoroutine(EnergyTimeCounter());
    }

    private void UpdateBar()
    {
        var (current, max) = _energy.GetCurrentEnergy();

        _energyValue.text = current.ToString();

        _maxEnergyValue.text = max.ToString();

        _energySlide.value = (float)current / (float)max;

    }

    private IEnumerator EnergyTimeCounter()
    {
        while (true)
        {
            _energy.Load();

            int currentMinutes = PlayerPrefs.GetInt(MinutesKey);

            _minutes.text = (60 - currentMinutes).ToString();

            _hours.text = "00";

            UpdateBar();

            yield return new WaitForSeconds(61);
        }
    }
}
