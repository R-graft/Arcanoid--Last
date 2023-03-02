public class BallDuplicate : BoostBlock
{
    public override void BoostEffect()
    {
        _collider.enabled = false;

        DuplicateBall();
    }

    private void DuplicateBall()
    {
        BonusEvents.OnDuplicateBall.Invoke(transform.position);
    }

    public override void InAnimation()
    {
        _collider.enabled = true;

        base.InAnimation();
    }
}
