using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private float _moveConstrainterX;

    private float _moveSpeed;

    private float _yPosition;

    private float _scale;

    private readonly Vector2 StartScale = new Vector2(2,2);

    public void Init()
    {
        _yPosition = transform.position.y;

        _moveSpeed = 0.1f;

        transform.localScale = StartScale;

        _scale = transform.localScale.x / 2;

        _moveConstrainterX = Camera.main.ScreenToWorldPoint(Vector2.zero).x;
    }

    public void Move(float _inputX)
    {
        var _direction = Mathf.Clamp(_inputX, _moveConstrainterX + _scale, -_moveConstrainterX - _scale);

        var moveDirection = new Vector2(_direction, _yPosition);

        transform.position = Vector2.MoveTowards(transform.position, moveDirection, _moveSpeed);
    }

    public void SetSpeed(bool isSpeedUp, float value)
    {
        _moveSpeed = isSpeedUp ? _moveSpeed *= value : _moveSpeed /= value;
    }

    public void SetScale(float value)
    {
        transform.localScale = new Vector2(transform.localScale.x + value, transform.localScale.y);

        _scale = transform.localScale.x / 2;
    } 
}
