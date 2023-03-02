using UnityEngine;

public class BonusMove : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * _speed * Time.fixedDeltaTime);
    }
}
