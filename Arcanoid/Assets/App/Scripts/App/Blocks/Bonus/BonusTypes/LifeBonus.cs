public class LifeBonus : Bonus
{
    private GamePanelController _controller;

    public override void Init()
    {
        _controller = LevelContext.Instance.GetSystem<GamePanelController>();
    }

    public override void Apply()
    {
        _controller.AddLife();
    }

    public override void Remove()
    {
    }
}
