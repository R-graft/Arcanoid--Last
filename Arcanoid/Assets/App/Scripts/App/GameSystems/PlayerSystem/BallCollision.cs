using System;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public Action<Collision2D> OnCollision;

    public Action<Collider2D> OnTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision?.Invoke(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTrigger?.Invoke(collision);
    }
}
