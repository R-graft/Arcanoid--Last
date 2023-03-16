using UnityEngine;

public class GameEntryPoint : EntryPoint
{
    [SerializeField] private LevelContext _levelContext;

    [SerializeField] private GameViewHandler _gameView;

    [SerializeField] private GameProgressHandler _gameProgress;

    [SerializeField] private GameSystemsHandler _gameSystems;

    [SerializeField] private GameUIWindow _gameUI;

    protected override void EntryInit()
    {
        base.EntryInit();

        _levelContext.InitContext();

        LevelController controller = new LevelController(_gameProgress, _gameSystems, _gameView);

        ProjectContext.Instance.AddService(controller);

        _gameView.InitLevelView(_gameUI);

        _gameProgress.InitLevelProgress(context.GetService<EnergyCounter>(), context.GetService<PackDataController>());

        _gameSystems.InitLevelSystems();
    }
}
