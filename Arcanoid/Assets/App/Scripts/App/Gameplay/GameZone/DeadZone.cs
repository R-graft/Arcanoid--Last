using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bonus bonus))
        {
            Destroy(bonus.gameObject);
        }

        if (collision.TryGetComponent(out Ball ball))
        {
            BallsController.OnBallDestroy?.Invoke(ball);
        }
    }
}
