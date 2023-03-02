public class BallSpeedBonus : Bonus
{
    public bool isSpeedUp;

    public int speedPercentValue;

    public override void Apply()
    {
        SwitchBallMode();
    }

    public override void Remove()
    {
        BonusEvents.OnBallSpeedBonus?.Invoke(!isSpeedUp, speedPercentValue);
    }

    private void SwitchBallMode()
    {
        BonusEvents.OnBallSpeedBonus?.Invoke(isSpeedUp, speedPercentValue);
    }
}
