using AOT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection:MonoBehaviour
{
    public Collider2D collider2d;

    public LayerMask platformLayer;

    public bool isGrounded;

    float extraHeight = 0.1f;

    private void FixedUpdate()
    {
        RaycastHit2D raycast = Physics2D.BoxCast
            (collider2d.bounds.center, collider2d.bounds.size, 0f, Vector2.down, extraHeight, platformLayer);
        isGrounded = raycast.collider != null;
    }
}
