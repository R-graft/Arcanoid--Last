public class PlatformResizeBonus : Bonus
{
    public float resizeValue;

    public override void Apply()
    {
        Resize();
    }

    public override void Remove()
    {
        BonusEvents.OnResizePlatform?.Invoke(-resizeValue);
    }

    private void Resize()
    {
        BonusEvents.OnResizePlatform?.Invoke(resizeValue);
    }
}
