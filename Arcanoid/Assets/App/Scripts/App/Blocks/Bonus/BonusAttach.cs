using UnityEngine;

public class BonusAttach : MonoBehaviour
{
    protected Bonus _currentBonus;

    protected BonusSystem _boosts;

    protected Transform _boostParent;

    public void Construct(Transform boostParent, Bonus currentBonus, BonusSystem boosts)
    {
        _currentBonus= currentBonus;
        _boosts = boosts;
        _boostParent= boostParent;
        _boosts.OnRestart += Deactivate;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            _boosts.ActivateBonus(_currentBonus);
        }

        Deactivate();
    }

    public virtual void Deactivate()
    {
        transform.parent = _boostParent;

        transform.localPosition = Vector3.zero;

        gameObject.SetActive(false);
    }
}

