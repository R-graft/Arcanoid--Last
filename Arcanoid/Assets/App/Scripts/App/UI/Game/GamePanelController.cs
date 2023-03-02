using System.Collections.Generic;
using UnityEngine;

public class GamePanelController : MonoBehaviour
{
    [SerializeField]
    private GamePanelView _interface;

    [SerializeField]
    private PacksData _packsData;

    [SerializeField]
    private GameObject _livesPanel;

    [SerializeField]
    private GameObject _lifePrefab;

    private List<GameObject> _livesList;

    public int LivesCount { get => _livesList.Count; }

    private const int StartLivesCount = 3;

    private const int MaxLivesCount = 5;

    private float _progressStep;

    public void StartSystem()
    {
        _interface.Init(_packsData);

        SetStartLives();
    }

    public void LivesCounter(int count, bool add)
    {
        _livesList ??= new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            if (add && _livesList.Count < MaxLivesCount)
            {
                var newLife = Instantiate(_lifePrefab, _livesPanel.transform);

                _livesList.Add(newLife);
            }

            else if (!add && _livesList.Count > 0)
            {
                Destroy(_livesList[0]);

                _livesList.RemoveAt(0);
            }
        }
    }

    public void SetStartLives()
    {
        if (_livesList == null)
        {
            LivesCounter(StartLivesCount, true);
        }
    }
    private void SetProgressStep(int count) => _progressStep = 1 / (float)count;

    private void SetLevelProgress() => _interface.SetProgress(_progressStep);

    private void OnEnable()
    {
        BlocksArranger.OnGetBlocksCount += SetProgressStep;

        BlocksSystem.OnBlockDestroyed += SetLevelProgress;

        BonusEvents.OnSetLives.AddListener(LivesCounter);
    }

    private void OnDisable()
    {
        BlocksArranger.OnGetBlocksCount -= SetProgressStep;

        BlocksSystem.OnBlockDestroyed -= SetLevelProgress;
    }
}
