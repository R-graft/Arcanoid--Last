using System;
using UnityEngine;

public class GamePanelController : GameSystem
{
    [Header("config")]
    public int startLivesCount = 3;

    [SerializeField] private GamePanelView _interface;

    private PackDataController _packsData;

    private BlocksSystem _blocks;

    private int _livesCount;

    private int _currentProgress;

    private int _progressStep;

    public override void InitSystem()
    {
        _packsData = ProjectContext.Instance.GetService<PackDataController>();

        _blocks = LevelContext.Instance.GetSystem<BlocksSystem>();

        _blocks.OnBlockDestroyed += LevelProgressCounter;

        _interface.Init(_packsData);

        _interface.RefreshPanel();

        ReStartSystem();
    }

    public override void StartSystem()
    {
        if (_livesCount == 0)
        {
            _controller.GameOver();
        }

        _livesCount--;

        _interface.RemoveLife();
    }

    public override void ReStartSystem()
    {
        _livesCount = startLivesCount;

        _interface.SetStartLives(_livesCount);

        RefreshLevelProgress();
    }
    public override void StopSystem()
    {
        _interface.RefreshPanel();

        RefreshLevelProgress();
    }

    private void LevelProgressCounter(int remainingBlocks)
    {
        if (_progressStep == 0)
        {
            _progressStep = (100 + remainingBlocks - 1) / remainingBlocks;
        }

        _currentProgress = _progressStep + _currentProgress > 100 ? 100 : _progressStep + _currentProgress;

        _interface.SetProgress(_currentProgress);
    }

    private void RefreshLevelProgress()
    {
        _progressStep = 0;
        _currentProgress = 0;
        _interface.SetProgress(_currentProgress);
    }

    public void AddLife()
    {
        if (_livesCount < startLivesCount)
        {
            _livesCount++;

            _interface.AddLife();
        }
    }

    public void RemoveLife()
    {
        if (_livesCount > 0)
        {
            _livesCount--;

            _interface.RemoveLife();
        }
    }
}
