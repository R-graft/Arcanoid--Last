using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSystemsHandler : MonoBehaviour, IGameHandler
{
    [SerializeField] private List<GameSystem> _gameSystemsList;

    public Action OnInit;
    public Action OnStart;
    public Action OnRestart;
    public Action OnStop;

    private Inputs _inputs;

    private LevelController _levelController;

    public void InitLevelSystems()
    {
        _inputs = ProjectContext.Instance.GetService<Inputs>();

        _inputs.TurnOff(false);

        foreach (var system in _gameSystemsList)
        {
            OnInit += system.InitSystem;
            OnStart += system.StartSystem;
            OnRestart += system.ReStartSystem;
            OnStop += system.StopSystem;

            system.SetHandler(_levelController);
        }

        OnInit.Invoke();
    }

    public void SetHandler(LevelController controller)
    {
        _levelController = controller;
    }
    

    public void SetStart()
    {
        OnStart.Invoke();
    }

    public void SetStop()
    {
        OnStop.Invoke();
    }

    public void SetOver()
    {
        _inputs.TurnOff(false);
    }

    public void SetLose()
    {
        _inputs.TurnOff(false);

        SetStart();
    }


    public void SetWin()
    {
        _inputs.TurnOff(false);

        SetStop();
    }

    public void SetRestart()
    {
        OnRestart.Invoke();
    }
}

public abstract class GameSystem : MonoBehaviour
{
    protected LevelController _controller;
    public abstract void InitSystem();
    public virtual void StartSystem()
    {
    }
    public virtual void ReStartSystem()
    {
    }
    public virtual void StopSystem()
    {
    }
    public void SetHandler(LevelController controller)
    {
        _controller = controller;
    }
}