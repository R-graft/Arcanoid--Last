using System;

public class LevelController
{
    public Action OnStartGame;
    public Action OnPauseGame;
    public Action OnRestarGame;
    public Action OnWinGame;
    public Action OnLoseGame;

    public LevelController(params IGameHandler[] handlers)
    {
        SubscribeOnGameEvents(handlers);

        SetController(handlers);
    }
    public void SetController(IGameHandler[] handlers)
    {
        foreach (var handler in handlers)
        {
            handler.InitController(this);
        }
    }
    public void SubscribeOnGameEvents(IGameHandler[] handlers)
    {
        foreach (var handler in handlers)
        {
            OnStartGame += handler.StartGame;
            OnPauseGame += handler.PauseGame;
            OnRestarGame += handler.RestartGame;
            OnLoseGame += handler.LoseGame;
            OnWinGame += handler.WinGame;
        }
    }
}

public interface IGameHandler
{
    public void InitController(LevelController controller);
    public void StartGame();

    public void PauseGame();

    public void RestartGame();

    public void WinGame();

    public void LoseGame();
}
