using UnityEngine;

public class BonusAttach : MonoBehaviour
{
    private Bonus _currentBonus;

    private BonusSystem _boosts;

    private Transform _boostParent;

    public void Construct(Transform boostParent, Bonus currentBonus, BonusSystem boosts)
    {
        _currentBonus= currentBonus;
        _boosts = boosts;
        _boostParent= boostParent;
        _boosts.OnRestart += Deactivate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            _boosts.ActivateBonus(_currentBonus);
        }

        Deactivate();
    }

    public void Deactivate()
    {
        transform.parent = _boostParent;

        transform.localPosition = Vector3.zero;

        gameObject.SetActive(false);
    }
}

