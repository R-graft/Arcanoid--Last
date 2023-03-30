using UnityEngine;

public class BallSpeed: MonoBehaviour
{
    [Header("config")]
    public float maxVelocityValue = 20;

    public float minVelocityValue = 2;

    public float StartForceIndex = 0.04f;

    [SerializeField] private Rigidbody2D _objectRb;

    private BlocksSystem _blocks;

    private float _accelerationIndex = 1;

    public static float currentVelocityMagnitude;

    public void StartMove(bool firstStart)
    {
        if (firstStart)
        {
            GetAccelerationIndex();

            currentVelocityMagnitude = 1;

            _objectRb.AddForce(Vector2.up * StartForceIndex);

            currentVelocityMagnitude = 10;
        }
        else
        {
            _objectRb.velocity = Vector2.up * currentVelocityMagnitude;
        }
    }

    public void CollisionSpeed()
    {
        if (_objectRb.velocity.magnitude > maxVelocityValue)
        {
            return;
        }
        else
        {
            _objectRb.velocity *= _accelerationIndex;

            currentVelocityMagnitude = _objectRb.velocity.magnitude;
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

    private void GetAccelerationIndex()
    {
        _blocks ??= LevelContext.Instance.GetSystem<BlocksSystem>();

        var blocksCount = _blocks.GetBlocksList().Count;

        _accelerationIndex = 1  + 1f / blocksCount;
    }
}
