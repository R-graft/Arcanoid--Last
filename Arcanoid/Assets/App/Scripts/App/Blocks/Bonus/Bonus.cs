
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] private BonusAttach _attach;

    public float time;

    public void Construct(Transform boostParent, BonusSystem boosts)
    {
        _attach.Construct(boostParent, this, boosts);
    }

    public abstract void Init();

    public abstract void Apply();

    public abstract void Remove();
}
