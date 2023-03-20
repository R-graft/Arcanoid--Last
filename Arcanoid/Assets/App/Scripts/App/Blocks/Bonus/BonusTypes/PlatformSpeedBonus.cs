public class PlatformSpeedBonus : Bonus
{
    private PlatformController _platform;

    public float speedValue;

    public bool isSpeedUp;

    public override void Init()
    {
        if (_platform == null)
        {
            _platform = LevelContext.Instance.GetSystem<PlatformController>();
        }
    }

    public override void Apply()
    {
        _platform.SetPlatformspeed(isSpeedUp, speedValue);
    }

    public override void Remove()
    {
        _platform.SetPlatformspeed(!isSpeedUp, speedValue);
    }
}
