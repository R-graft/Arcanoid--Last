using UnityEngine;

public class PlatformMove
{
    private Transform _platform;

    private Vector2 _startPlatformPosition;

    private float _moveConstrainterX;

    private float _moveSpeed;

    private float _scale;

    private float _defaultSpeed;

    public PlatformMove(Transform platform, Vector2 startPlatformPosition, float moveConstrainer, float moveSpeed)
    {
        _platform = platform;

        _startPlatformPosition = startPlatformPosition;

        _moveConstrainterX = moveConstrainer;

        _defaultSpeed = moveSpeed;
    }

    public void Reset()
    {
        _platform.position = _startPlatformPosition;

        _moveSpeed = _defaultSpeed;

        _scale = _platform.localScale.x;
    }

    public void Move(float _inputX)
    {
        var _direction = Mathf.Clamp(_inputX, _moveConstrainterX + _scale, -_moveConstrainterX - _scale);

        var moveDirection = new Vector2(_direction, _startPlatformPosition.y);

        _platform.position = Vector2.MoveTowards(_platform.position, moveDirection, _moveSpeed);
    }

    public void SetSpeed(bool isSpeedUp, float value)
    {
        _moveSpeed = isSpeedUp ? _moveSpeed *= value : _moveSpeed /= value;
    }

    public void SetScale(float value)
    {
        _platform.localScale = new Vector2(_platform.localScale.x + value, _platform.localScale.y);

        _scale = _platform.localScale.x / 2;
    } 
}
