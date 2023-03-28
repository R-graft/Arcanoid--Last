using UnityEngine;
using UnityEngine.EventSystems;

public class BallLauncher : GameSystem, IPointerUpHandler, IPointerDownHandler
{
    [Header("config")]
    public float BallOffset = 0.4f;

    public float StartForceIndex = 0.04f;

    [Header("components")]
    private BallsController _ballsController;

    private PlatformController _platformController;

    private Inputs _inputs;

    private BallHandler _startedBall;

    private Transform _platformTransform;

    private BlocksSystem _blocks;

    private bool _firstStart;


    public override void InitSystem()
    {
        _inputs = ProjectContext.Instance.GetService<Inputs>();

        _ballsController = LevelContext.Instance.GetSystem<BallsController>();

        _platformController = LevelContext.Instance.GetSystem<PlatformController>();

        ReStartSystem();
    }

    public override void StartSystem()
    {
        _firstStart = false;

        InitLauncher();
    }
    public override void StopSystem()
    {
        
    }
    public override void ReStartSystem()
    {
        _firstStart = true;

        InitLauncher();
    }

    private void InitLauncher()
    {
        _blocks ??= LevelContext.Instance.GetSystem<BlocksSystem>();

        _inputs.TurnOff(false);

        _startedBall = _ballsController.GetBall();

        _platformTransform = _platformController.GetTransform();

        _startedBall.transform.parent = _platformTransform;

        gameObject.SetActive(true);
    }
    private void Launch()
    {
        _startedBall.transform.parent = _ballsController.transform;

        _startedBall.StartBallMove(_firstStart);

        gameObject.SetActive(false);
    }
    private void FollowPlatform()
    {
        _inputs.TurnOn(false);
    }
    public void OnPointerUp(PointerEventData eventData) => Launch();

    public void OnPointerDown(PointerEventData eventData) => FollowPlatform();
}

