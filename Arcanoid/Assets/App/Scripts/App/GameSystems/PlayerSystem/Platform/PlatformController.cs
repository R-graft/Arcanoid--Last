using System;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Header("config")]
    public Vector2 _startPlatformPosition = new Vector2(0, -3.2f);

    [SerializeField] private PlatformMove _platformMove;

    public static Func<Transform> OnGetTransform;

    public void Init()
    {
        _platformMove = Instantiate(_platformMove, transform);

        _platformMove.transform.position = _startPlatformPosition;

        _platformMove.Init();

        OnGetTransform += GetTransform;
    }

    public void RestartSystem()
    {
        _platformMove.transform.position = _startPlatformPosition;

        _platformMove.Init();
    }
    public void DestroyPlatform()
    {
        if (_platformMove)
        {
            Inputs._inputPositionX -= _platformMove.Move;

            Destroy(_platformMove.gameObject);
        }
    }

    public Transform GetTransform() => _platformMove.transform;

    private void OnEnable()
    {
        BonusEvents.OnResizePlatform.AddListener(_platformMove.SetScale);
        BonusEvents.OnSetPlatformSpeed.AddListener(_platformMove.SetSpeed);

        Inputs._inputPositionX += _platformMove.Move;
    }

    private void OnDisable()
    {
        Inputs._inputPositionX -= _platformMove.Move;

        OnGetTransform -= GetTransform;
    }
}
