public class BallDuplicate : BoostBlock
{
    private BallsController _balls;

    protected override void InitBoost()
    {
        _balls = LevelContext.Instance.GetSystem<BallsController>();
    }

    public override void BoostEffect()
    {
        _balls.AddBall(transform.position);
    }
}
