public class PlatformResizeBonus : Bonus
{
    private PlatformController _platform;

    public float scaleValue;

    public override void Init()
    {
        if (_platform == null)
        {
            _platform = LevelContext.Instance.GetSystem<PlatformController>();
        }
    }

    public override void Apply()
    {
        _platform.ResizePlatform(scaleValue);
    }

    public override void Remove()
    {
        _platform.ResizePlatform(1);
    }
}
