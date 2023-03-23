using UnityEngine;

public class GameEntryPoint : EntryPoint
{
    [SerializeField] private LevelContext _levelContext;

    [SerializeField] private GameProgressHandler _gameProgress;

    [SerializeField] private GameSystemsHandler _gameSystems;

    [SerializeField] private GameUIWindow _gameUI;

    protected override void EntryInit()
    {
        base.EntryInit();

        _levelContext.InitContext();

        LevelController controller = ProjectContext.Instance.GetService<LevelController>();

        controller.Construct(_gameProgress, _gameSystems);

        _gameProgress.InitLevelProgress(context.GetService<EnergyCounter>(), context.GetService<PackDataController>());

        _gameSystems.InitLevelSystems();
    }
}
