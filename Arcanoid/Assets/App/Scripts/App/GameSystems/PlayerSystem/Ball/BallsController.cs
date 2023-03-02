using System;
using System.Collections.Generic;
using UnityEngine;

public class BallsController : MonoBehaviour
{
    [Header("config")]
    public Vector2 _startBallPosition = new Vector2(0, -5.5f);

    [SerializeField] private Ball _ballPrefab;

    [SerializeField] private BallLauncher _launcherHandler;

	private List<Ball> _balls;

    public static Action<Ball> OnBallDestroy;

    public static Action OnBallIsFall;

    public void Init()
	{
        _balls = new List<Ball>();

        CreateBall(_startBallPosition);

        LaunchBall();
    }

    private void LaunchBall()
    {
        _launcherHandler.gameObject.SetActive(true);

        _launcherHandler.Init(_balls[0].BallRb, PlatformController.OnGetTransform.Invoke());
    }
    public void RestartSystem()
    {
        ClearBalls();

        CreateBall(_startBallPosition);

        LaunchBall();
    }

    private void CreateBall(Vector2 position)
	{
        Ball newBall = Instantiate(_ballPrefab, transform);

        newBall.transform.position = position;

        _balls.Add(newBall);
    }

    private void DestroyBall(Ball ball)
    {
        if (_balls.Contains(ball))
        {
            _balls.Remove(ball);

            Destroy(ball.gameObject);

            if (_balls.Count == 0)
                OnBallIsFall?.Invoke();
        }
    }

    private void ClearBalls()
    {
        if (_balls.Count != 0)
        {
            foreach (var item in _balls)
                Destroy(item.gameObject);

            _balls.Clear();
        }
    }

    public void StopBalls()
    {
        if (_balls.Count != 0)
        {
            foreach (var item in _balls)
                item.BallRb.velocity = Vector2.zero;
        }
    }

    private void BonusBall(Vector2 position)
    {
        CreateBall(position);

        _balls[_balls.Count - 1].BallRb.velocity = _balls[_balls.Count - 2].BallRb.velocity;
    }

    private void OnEnable()
    {
        OnBallDestroy += DestroyBall;

        BonusEvents.OnDuplicateBall.AddListener(BonusBall);
    }
    private void OnDisable()
    {
        OnBallDestroy -= DestroyBall;
    }
}
