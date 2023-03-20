using UnityEngine;

public class PlatformTransform : MonoBehaviour
{
    [SerializeField] private Transform _basePlatform;

    [SerializeField] private Transform _centerPlatform;

    private Vector2 _startPlatformPosition;

    private float _moveConstrainterX;

    private float _moveSpeed;

    private float _defaultSpeed;

    //private void Update()
    //{
    //    print(_moveSpeed);
    //}
    public void Construct(Vector2 startPlatformPosition, float moveConstrainer, float moveSpeed)
    {
        _startPlatformPosition = startPlatformPosition;

        _moveConstrainterX = moveConstrainer;

        _defaultSpeed = moveSpeed;
    }

    public void ResetTransform()
    {
        transform.position = _startPlatformPosition;

        _moveSpeed = _defaultSpeed;

        _basePlatform.localScale = Vector3.one;
    }

    public void Move(float _inputX)
    {
        var _direction = Mathf.Clamp(_inputX, _moveConstrainterX + _basePlatform.localScale.x / 1.2f, -_moveConstrainterX - _basePlatform.localScale.x / 1.2f);

        var moveDirection = new Vector2(_direction, _startPlatformPosition.y);

        transform.position = Vector2.MoveTowards(_basePlatform.position, moveDirection, _moveSpeed * Time.deltaTime);
    }

    public void SetSpeed(bool isSpeedUp, float value)
    {
        _moveSpeed = isSpeedUp ? _moveSpeed *= value : _moveSpeed /= value;
    }

    public void SetScale(bool isSizeUp, float value)
    {
        float sizeX = isSizeUp? _basePlatform.localScale.x * value: _basePlatform.localScale.x / value;

        _basePlatform.localScale = new Vector2(sizeX, _basePlatform.localScale.y);
    } 
}
