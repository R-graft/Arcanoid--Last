using UnityEngine;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _ballRb;

    [SerializeField] private BallSpeed _speed;

    [SerializeField] private BallCollision _collision;

    [SerializeField] private BallBounce _bounce;

    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private TrailRenderer _trail;

    private Vector2 _currentVelocity;

    public Rigidbody2D GetRb() => _ballRb;

    public void StopBallMove()
    {
        _currentVelocity = _ballRb.velocity;

        _ballRb.velocity = Vector2.zero;
    }

    public void StartBallMove()
    {
        _ballRb.velocity = _currentVelocity;
    }

    public void EditBallSpeed(bool isSpeedUp, int percentValue)
    {
        _speed.EditSpeed(isSpeedUp, percentValue);
    }

    public void SetBallSpeed(Vector2 speed)
    {
        _speed.SetCurrentSpeed(speed);
    }

    public void SetFury(bool isFury)
    {
        _renderer.color = isFury ? Color.red : Color.white;

        _trail.emitting = isFury;
    }
}
