using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private BallCollision _collisionController;

    [SerializeField]
    private BallBounce _bounce;

    [SerializeField]
    private BallSpeed _speed;

    [SerializeField]
    private BallDamage _damage;

    [SerializeField]
    private BallSounds _sounds;

    public Rigidbody2D BallRb { get => _rb; }

    private void CollisionHandler(Collision2D collision)
    {
        if (_damage.TryDamage(collision))
        {
            _speed.OnBlockCollision();
        }
        _sounds.GetSoundTouch();

        _bounce.TryAngleCorrect(collision);
    }

    private void TriggerCollisionHandler(Collider2D collision)
    {
        _damage.TryTriggerDamage(collision);
    }

    private void OnEnable()
    {
        _collisionController.OnCollision += CollisionHandler;

        _collisionController.OnTrigger += TriggerCollisionHandler;

        BonusEvents.OnBallSpeedBonus.AddListener(_speed.EditSpeed);
    }
    private void OnDisable()
    {
        _collisionController.OnCollision -= CollisionHandler;

        _collisionController.OnTrigger -= TriggerCollisionHandler;
    }
}
