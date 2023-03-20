using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private BallsController _ballsController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_ballsController)
        {
            _ballsController = LevelContext.Instance.GetSystem<BallsController>();
        }

        if (collision.TryGetComponent(out BallHandler ball))
        {
            _ballsController.Fall(ball);
        }
    }
}
