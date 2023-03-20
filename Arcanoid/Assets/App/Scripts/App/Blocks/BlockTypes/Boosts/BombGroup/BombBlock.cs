using System.Collections.Generic;
using UnityEngine;

public abstract class BombBlock : BoostBlock
{
    protected BlocksDamageHandler _damage;

    protected BlocksArrangeSystem _arranger;

    protected FieldGridSystem _grid;

    protected Dictionary<Vector2, Block> _currentLevelsBlocks;

    protected List<IDamageable> _currentTargets;

    protected List<(int x, int y)> _targetIndexes;

    public int bombDamage;

    protected override void InitBoost()
    {
        _damage = LevelContext.Instance.GetSystem<BlocksDamageHandler>();

        _arranger = LevelContext.Instance.GetSystem<BlocksArrangeSystem>();

        _grid = LevelContext.Instance.GetSystem<FieldGridSystem>();

        _currentLevelsBlocks = _arranger.BlocksGrid;

        _targetIndexes = new List<(int, int)>();

        GetTargetIndexes();

        SetTargetBlocks();
    }

    protected abstract void GetTargetIndexes();

    protected virtual void SetTargetBlocks()
    {
        _currentTargets = new List<IDamageable>();

        foreach (var (x, y) in _targetIndexes)
        {
            var current = new Vector2(x, y);

            if (_currentLevelsBlocks.ContainsKey(current) && _selfGridIndex != current)
            {
                if (_currentLevelsBlocks[current].TryGetComponent(out IDamageable dam))
                {
                    _currentTargets.Add(dam);
                }
            }
        }
    }

    public override void BoostEffect()
    {
        foreach (var target in _currentTargets)
        {
            _damage.SetDamage(target, bombDamage);
        }
    }
}
