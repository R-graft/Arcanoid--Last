public class FuryBallBonus : Bonus
{
    private BlocksSystem _blocks;

    private BallsController _balls;
    public override void Init()
    {
       _blocks = LevelContext.Instance.GetSystem<BlocksSystem>();

       _balls = LevelContext.Instance.GetSystem<BallsController>();
    }

    public override void Apply()
    {
        _blocks.SetBlocksCollider(true);
        _balls.EditBallView(true);
    }

    public override void Remove()
    {
        _blocks.SetBlocksCollider(false);
        _balls.EditBallView(false);
    }
}
