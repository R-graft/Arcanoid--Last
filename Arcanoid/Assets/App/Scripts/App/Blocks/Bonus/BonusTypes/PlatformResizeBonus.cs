public class PlatformResizeBonus : Bonus
{
    private PlatformController _platform;

    public float resizeValue = 2;

    public bool isSizeUp;

    public override void Init()
    {
        if (_platform == null)
        {
            _platform = LevelContext.Instance.GetSystem<PlatformController>();
        }
    }

    public override void Apply()
    {
        _platform.ResizePlatform(isSizeUp, resizeValue);
    }

    public override void Remove()
    {
        _platform.ResizePlatform(!isSizeUp, resizeValue);
    }
}
