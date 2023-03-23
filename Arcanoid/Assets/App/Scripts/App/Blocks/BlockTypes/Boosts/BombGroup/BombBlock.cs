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

    protected float _damagingHold = 0.1f;

    protected override void InitBoost()
    {
        _damage = LevelContext.Instance.GetSystem<BlocksDamageHandler>();

        _arranger = LevelContext.Instance.GetSystem<BlocksArrangeSystem>();

        _grid = LevelContext.Instance.GetSystem<FieldGridSystem>();

        _targetIndexes = new List<(int, int)>();

        GetTargetIndexes();
    }

    protected abstract void GetTargetIndexes();

    protected virtual void SetTargetBlocks()
    {
        _currentLevelsBlocks = _arranger.BlocksGrid;

        _currentTargets = new List<IDamageable>();

        foreach (var (x, y) in _targetIndexes)
        {
            var current = new Vector2(x, y);

            if (_currentLevelsBlocks.ContainsKey(current) && _currentLevelsBlocks[current].gameObject.activeSelf && _selfGridIndex != current)
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
        SetTargetBlocks();

        _damage.SetArrayDamage(_currentTargets, bombDamage, _damagingHold);
    }
}
