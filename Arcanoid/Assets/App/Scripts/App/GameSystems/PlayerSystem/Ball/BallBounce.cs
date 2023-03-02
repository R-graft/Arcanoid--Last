using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _objectRb;

    private Vector2 _priviousPosition;

    private const float _minBounseAngle = 3;

    private const float _maxForceIndex = 0.003f;

    private const float _minForceIndex = 0.001f;
    public BallBounce(Rigidbody2D rb)
    {
        _objectRb = rb;
    }

    public void TryAngleCorrect(Collision2D collision)
    {
        var collisionNormal = collision.contacts[0].normal;

        var ballDirection = _priviousPosition - collision.contacts[0].point;

        var collisionAngle = Vector2.Angle(ballDirection, collisionNormal);

        if (collisionAngle < _minBounseAngle)
        {
            _objectRb.AddForce(new Vector2(collisionNormal.y, collisionNormal.x) * Random.Range(_minForceIndex, _maxForceIndex));
        }
        _priviousPosition = collision.contacts[0].point;
    }
}
