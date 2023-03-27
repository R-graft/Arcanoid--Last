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

    private Rigidbody2D _ballRb;

    private Transform _platformTransform;

    public override void InitSystem()
    {
        _inputs = ProjectContext.Instance.GetService<Inputs>();

        _ballsController = LevelContext.Instance.GetSystem<BallsController>();

        _platformController = LevelContext.Instance.GetSystem<PlatformController>();

        ReStartSystem();
    }

    public override void StartSystem()
    {
        ReStartSystem();
    }
    public override void ReStartSystem()
    {
        _inputs.TurnOff(false);

        _ballRb = _ballsController.GetBall();

        _platformTransform = _platformController.GetTransform();

        _ballRb.transform.parent = _platformTransform;

        gameObject.SetActive(true);
    }
    private void Launch()
    {
        _ballRb.transform.parent = _ballsController.transform;

        _ballRb.AddForce(Vector2.up * StartForceIndex);

        gameObject.SetActive(false);
    }
    private void FollowPlatform()
    {
        _inputs.TurnOn(false);
    }
    public void OnPointerUp(PointerEventData eventData) => Launch();

    public void OnPointerDown(PointerEventData eventData) => FollowPlatform();
}
