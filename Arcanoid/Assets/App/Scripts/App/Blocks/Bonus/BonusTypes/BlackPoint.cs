
public class BlackPoint : Bonus
{
    private GamePanelController _controller;

    public override void Init()
    {
        _controller = LevelContext.Instance.GetSystem<GamePanelController>();
    }

    public override void Apply()
    {
        _controller.RemoveLife();
    }

    public override void Remove()
    {
    }
}
