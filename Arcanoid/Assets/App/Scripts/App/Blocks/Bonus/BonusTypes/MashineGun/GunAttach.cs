using UnityEngine;

public class GunAttach : BonusAttach
{
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private BonusMove _move;

    private Transform _platform;

    private new  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            _platform = collision.gameObject.transform;

            Attach();

            _boosts.ActivateBonus(_currentBonus);
        }
    }

    public void Attach()
    {
        transform.SetParent(_platform);

        _renderer.enabled = false;

        _move.enabled= false;
    }
    public override void Deactivate()
    {
        transform.parent = _boostParent;

        transform.localPosition = Vector3.zero;

        gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        _renderer.enabled = true;

        _move.enabled = true;
    }
}
