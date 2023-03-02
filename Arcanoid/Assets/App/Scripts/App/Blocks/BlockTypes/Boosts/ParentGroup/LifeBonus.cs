public class LifeBonus : Bonus
{
    public bool isLifeUp;

    private const int BonusLivesCount = 1;
    public override void Apply()
    {
        Resize();
    }

    public override void Remove()
    {

    }

    private void Resize()
    {
        BonusEvents.OnSetLives.Invoke(BonusLivesCount, isLifeUp);
    }
}
