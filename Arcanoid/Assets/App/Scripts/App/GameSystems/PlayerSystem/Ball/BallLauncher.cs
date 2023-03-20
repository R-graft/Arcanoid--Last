using System.Collections;
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
        _inputs =ProjectContext.Instance.GetService<Inputs>();

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
        _ballRb = _ballsController.GetBall();

        _platformTransform = _platformController.GetTransform();

        gameObject.SetActive(true);
    }
    private void Launch()
    {
        var startDirection = _ballRb.position.normalized;

        _ballRb.AddForce(new Vector2(startDirection.x, - startDirection.y) * StartForceIndex);

        gameObject.SetActive(false);
    }
    private IEnumerator FollowPlatform()
    {
        _inputs.TurnOn(false);

        while (true)
        {
            _ballRb.position = new Vector2(_platformTransform.position.x, _platformTransform.position.y + BallOffset);

            yield return null;
        }
    }
    public void OnPointerUp(PointerEventData eventData) => Launch();

    public void OnPointerDown(PointerEventData eventData) => StartCoroutine(FollowPlatform());

  

    
}
