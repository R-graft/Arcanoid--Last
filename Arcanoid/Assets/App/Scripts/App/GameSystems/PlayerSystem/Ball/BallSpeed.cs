using UnityEngine;

public class BallSpeed: MonoBehaviour
{
    [SerializeField] private Rigidbody2D _objectRb;

    private const float _accelerationIndex = 1.02f;

    private const float _maxVelocityValue = 15;

    private const float _minVelocityValue = 2;

    public void CollisionSpeed()
    {
        if (_objectRb.velocity.magnitude < _maxVelocityValue)
        {
            _objectRb.velocity *= _accelerationIndex;
        }
    }

    public void EditSpeed(bool isSpeedUp, int percentValue)
    {
        if (isSpeedUp && _objectRb.velocity.magnitude < _maxVelocityValue)
        {
            _objectRb.velocity *= (100/percentValue);
        }

        else if (!isSpeedUp && _objectRb.velocity.magnitude > _minVelocityValue)
        {
            _objectRb.velocity /= (100 / percentValue);
        }
    }

    public void SetCurrentSpeed(Vector2 currentVelocity)
    {
        _objectRb.velocity= currentVelocity;
    }
}
