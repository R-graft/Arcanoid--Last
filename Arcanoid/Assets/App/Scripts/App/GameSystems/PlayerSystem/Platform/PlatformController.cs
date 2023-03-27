using UnityEngine;

public class PlatformController : GameSystem
{
    [Header("config")]
    public Vector2 startPlatformPosition = new Vector2(0, -3.2f);

    public float moveSpeed = 0.1f;

    public float constrainerCoefficient = 1.2f;

    [Header("components")]
    [SerializeField] private Camera _mCamera;

    [SerializeField] private PlatformTransform _transformer;

    private Inputs _inputs;

    private float _moveConstrainer;

    public override void InitSystem()
    {
        InitPlatform();

        _inputs._inputPositionX += _transformer.Move;
    }

    public override void StartSystem()
    {
        _transformer.ResetTransform();
    }

    public override void ReStartSystem()
    {
        _transformer.ResetTransform();
    }

    private void InitPlatform()
    {
        _inputs = ProjectContext.Instance.GetService<Inputs>();

        _moveConstrainer = _mCamera.ScreenToWorldPoint(Vector2.zero).x;

        _moveConstrainer *= constrainerCoefficient;

        _transformer = Instantiate(_transformer, transform);

        _transformer.Construct(startPlatformPosition, _moveConstrainer, moveSpeed);

        _transformer.ResetTransform();
    }

    public Transform GetTransform() => _transformer.transform;

    public void ResizePlatform(float value)
    {
        _transformer.SetScale(value);
    }

    public void SetPlatformspeed(bool isSpeedUp, float value)
    {
        _transformer.SetSpeed(isSpeedUp, value);
    }
    private void OnDisable()
    {
        _inputs._inputPositionX -= _transformer.Move;
    }
}
