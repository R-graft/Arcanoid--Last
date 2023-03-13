using UnityEngine;

public class GameEntryPoint : EntryPoint
{
    [SerializeField] private GameViewHandler _levelView;

    [SerializeField] private GameProgressHandler _levelProgress;

    [SerializeField] private GameSystemsHandler _levelSystems;

    [SerializeField] private GameUIWindow _gameUI;

    private LevelController _controller;

    protected override void EntryInit()
    {
        base.EntryInit();

        _levelView.InitLevelView(_gameUI);

        _levelProgress.InitLevelProgress(context.GetService<EnergyCounter>(), context.GetService<PackDataController>());

        _levelSystems.InitSystems(context.GetService<Inputs>());

        _controller = new LevelController(_levelProgress, _levelSystems, _levelView);

        _controller.OnStartGame.Invoke();
    }
}
