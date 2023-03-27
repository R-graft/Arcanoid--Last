using UnityEngine;

public class BallSpeed: MonoBehaviour
{
    [Header("config")]
    public float accelerationIndex = 1.02f;

    public float maxVelocityValue = 15;

    public float minVelocityValue = 2;

    [SerializeField] private Rigidbody2D _objectRb;

    public void CollisionSpeed()
    {
        if (_objectRb.velocity.magnitude < maxVelocityValue)
        {
            _objectRb.velocity *= accelerationIndex;
        }
    }

    public void EditSpeed(bool isSpeedUp, int percentValue)
    {
        if (isSpeedUp && _objectRb.velocity.magnitude < maxVelocityValue)
        {
            _objectRb.velocity *= (100/percentValue);
        }

        else if (!isSpeedUp && _objectRb.velocity.magnitude > minVelocityValue)
        {
            _objectRb.velocity /= (100 / percentValue);
        }
    }

    public void SetCurrentSpeed(Vector2 currentVelocity)
    {
        _objectRb.velocity= currentVelocity;
    }
}
