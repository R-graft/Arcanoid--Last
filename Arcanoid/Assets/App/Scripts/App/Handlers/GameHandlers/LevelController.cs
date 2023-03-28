using System;

public class LevelController : IService
{
    private Inputs _inputs;

    public Action OnStartGame;
    public Action OnRestartGame;
    public Action OnGameOver;
    public Action OnWinGame;
    public Action OnLoseGame;
    public Action OnLevelIsLoaded;

    public void Construct(Inputs inputs, params IGameHandler[] handlers)
    {
        _inputs = inputs;

        SubscribeOnGameEvents(handlers);

        SetController(handlers);
    }
    private void SetController(IGameHandler[] handlers)
    {
        foreach (var handler in handlers)
        {
            handler.SetHandler(this);
        }
    }
    private void SubscribeOnGameEvents(IGameHandler[] handlers)
    {
        foreach (var handler in handlers)
        {
            OnStartGame += handler.SetStart;
            OnRestartGame += handler.SetRestart;
            OnGameOver += handler.SetOver;
            OnLoseGame += handler.SetLose;
            OnWinGame += handler.SetWin;
            OnLevelIsLoaded += handler.SystemLoaded;
        }
    }

    public void Start() => OnStartGame.Invoke();
    public void Restart() => OnRestartGame?.Invoke();
    public void GameOver()=> OnGameOver.Invoke();
    public void Win() => OnWinGame.Invoke();
    public void Lose() => OnLoseGame.Invoke();

    public void LevelIsLoaded()
    {
        OnLevelIsLoaded.Invoke();

        _inputs.TurnOn(true);
    }


    public void InitService()
    {
    }
}

public interface IGameHandler
{
    public void SetHandler(LevelController controller);
    public void SetStart();
    public void SetRestart();
    public void SetOver();
    public void SetWin();
    public void SetLose();
    public void SystemLoaded();
}
