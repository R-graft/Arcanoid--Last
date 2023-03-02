public class FuryBallBonus : Bonus
{
    public override void Apply()
    {
        SwitchBallMode();
    }

    public override void Remove()
    {
        BonusEvents.OnFuryBallBonus?.Invoke(false);
    }

    private void SwitchBallMode()
    {
        BonusEvents.OnFuryBallBonus?.Invoke(true);
    }
}
