using UnityEngine;

public class BonusAttach : MonoBehaviour
{
    [SerializeField]
    private Bonus _bonus;

    [SerializeField]
    private SpriteRenderer _renderer;

    [SerializeField]
    private BonusMove _bonusMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            Attach(collision.gameObject.transform);

            BoostSystem.OnBonusActivation.Invoke(_bonus);
        }
    }
    private void Attach(Transform _transform)
    {
        transform.localPosition = Vector3.zero;

        _renderer.enabled = false;

        _bonusMove.enabled = false;
    }
}

