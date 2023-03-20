using System;
using System.Collections.Generic;
using UnityEngine;

public class BallsController : GameSystem
{
    [Header("config")]
    public Vector2 _startBallPosition = new Vector2(0, -5.5f);

    public Vector2 addedBallSpeed = Vector2.down;

    [SerializeField] private BallHandler _ballPrefab;

	private List<BallHandler> _balls;

    private BallHandler _currentBall;

    public Action OnBallIsFall;

    public override void InitSystem()
    {
        _balls = new List<BallHandler>();

        CreateBall(_startBallPosition);

        _currentBall = _balls[0]; 
    }

    public override void StartSystem()
    {
        ClearBalls();
    }

    public override void StopSystem()
    {
        StopBalls();
    }

    public override void ReStartSystem()
    {
        ClearBalls();
    }
    public void AddBall(Vector2 position)
    {
        var addedBall = CreateBall(position);

        addedBall.SetBallSpeed(_currentBall.GetRb().velocity.magnitude * addedBallSpeed);
    }

    private BallHandler CreateBall(Vector2 position)
	{
        var newBall = Instantiate(_ballPrefab, transform);

        newBall.transform.position = position;

        _balls.Add(newBall);

        return newBall;
    }

    public void Fall(BallHandler ball)
    {
        if (_balls.Contains(ball))
        {
            if (_balls.Count == 1)
            {
                _currentBall = ball;

                _controller.Lose();
            }
            else
            {
                _balls.Remove(ball);

                Destroy(ball.gameObject);

                _currentBall = _balls[0];
            }
        }
    }

    private void ClearBalls()
    {
        _currentBall = _balls[0];

        if (_balls.Count > 1)
        {
            for (int i = 1; i < _balls.Count; i++)
            {
                Destroy(_balls[i].gameObject);
            }

            _balls.Clear();

            _balls.Add(_currentBall);
        }

        _currentBall.GetRb().velocity = Vector2.zero;

        _currentBall.transform.position = _startBallPosition;
    }

    private void StopBalls()
    {
        if (_balls.Count != 0)
        {
            foreach (var item in _balls)
                item.StopBallMove();
        }
    }
    private void StartBalls()
    {
        if (_balls.Count != 0)
        {
            foreach (var item in _balls)
                item.StartBallMove();
        }
    }

    public void EditBallsSpeed(bool isSpeedUp, int value)
    {
        foreach (var ball in _balls)
        {
            ball.EditBallSpeed(isSpeedUp, value);
        }
    }

    public Rigidbody2D GetBall() => _currentBall.GetRb();

}
