using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [Header("config")]
    public float minBounseAngle = 3;

    public float maxForceIndex = 0.003f;

    public float minForceIndex = 0.001f;

    [SerializeField] private Rigidbody2D _objectRb;

    private Vector2 _priviousPosition;

    public void TryAngleCorrect(Collision2D collision)
    {
        var collisionNormal = collision.contacts[0].normal;

        var ballDirection = _priviousPosition - collision.contacts[0].point;

        var collisionAngle = Vector2.Angle(ballDirection, collisionNormal);

        if (collisionAngle < minBounseAngle)
        {
            _objectRb.AddForce(new Vector2(collisionNormal.y, collisionNormal.x) * Random.Range(minForceIndex, maxForceIndex));
        }
        _priviousPosition = collision.contacts[0].point;
    }
}
