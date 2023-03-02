using System.Collections.Generic;
public abstract class BombBlock : BoostBlock
{
    protected List<(int x, int y)> _currentIndexes;

    protected (int x, int y)[] _targetIndexes;

    protected int _damage;

    protected abstract void SetTargetIndexes();

    public override void BoostEffect()
    {
        BonusEvents.OnBombBonus.Invoke(_currentIndexes, _damage);
    }

    protected void OnEnable()
    {
        BlocksArranger.OnBlocksGridFull += SetTargetIndexes;
    }
    protected void OnDisable()
    {
        BlocksArranger.OnBlocksGridFull -= SetTargetIndexes;
    }
}
