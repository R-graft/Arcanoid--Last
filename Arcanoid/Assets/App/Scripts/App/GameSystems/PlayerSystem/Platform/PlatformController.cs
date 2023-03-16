using UnityEngine;

public class PlatformController : GameSystem
{
    [Header("config")]
    public Vector2 _startPlatformPosition = new Vector2(0, -3.2f);

    public float moveSpeed = 0.1f;

    [Header("components")]
    [SerializeField] private GameObject _platform;

    [SerializeField] private Camera _mCamera;

    private PlatformMove _mover;

    private Inputs _inputs;

    private float _moveConstrainer;

    public override void InitSystem()
    {
        InitPlatform();

        _inputs._inputPositionX += _mover.Move;
    }

    public override void StartSystem()
    {
        _mover.Reset();
    }

    public override void StopSystem()
    {
        _inputs._inputPositionX -= _mover.Move;
    }
    public override void ReStartSystem()
    {
        _inputs._inputPositionX += _mover.Move;

        _mover.Reset();
    }

    private void InitPlatform()
    {
        _inputs = ProjectContext.Instance.GetService<Inputs>();

        _platform = Instantiate(_platform, transform);

        _moveConstrainer = _mCamera.ScreenToWorldPoint(Vector2.zero).x;

        _mover = new PlatformMove(_platform.transform, _startPlatformPosition, _moveConstrainer, moveSpeed);

        _mover.Reset();
    }

    public Transform GetTransform() => _platform.transform;

    private void OnDisable()
    {
        _inputs._inputPositionX -= _mover.Move;
    }
}
