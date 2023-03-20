public class BallSpeedBonus : Bonus
{
    private BallsController _balls;

    public bool isSpeedUp;

    public int speedPercentValue;

    public override void Init()
    {
        _balls = LevelContext.Instance.GetSystem<BallsController>();
    }

    public override void Apply()
    {
        _balls.EditBallsSpeed(isSpeedUp, speedPercentValue);
    }

    public override void Remove()
    {
        _balls.EditBallsSpeed(!isSpeedUp, speedPercentValue);
    }
}
