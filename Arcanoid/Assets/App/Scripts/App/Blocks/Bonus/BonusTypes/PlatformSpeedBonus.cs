public class PlatformSpeedBonus : Bonus
{
    public bool isSpeedUp;

    public float speedValue;
    public override void Apply()
    {
        Resize();
    }

    public override void Remove()
    {
        BonusEvents.OnSetPlatformSpeed?.Invoke(!isSpeedUp, speedValue);

    }

    private void Resize()
    {
        BonusEvents.OnSetPlatformSpeed?.Invoke(isSpeedUp, speedValue);
    }
}
