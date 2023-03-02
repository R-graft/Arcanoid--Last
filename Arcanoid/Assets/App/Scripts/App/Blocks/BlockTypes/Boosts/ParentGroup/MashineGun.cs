using UnityEngine;
public class MashineGun : ParentBonusBlock
{
    [SerializeField] private MashineGunBonus _bonusPrefab;

    protected override void SetChildBonus() => _childBonus = _bonusPrefab;
}
