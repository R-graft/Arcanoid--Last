using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3;

    public bool goLeft = true;

    public Transform left;

    public Transform right;

    void FixedUpdate()
    {
        if (goLeft)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if (!goLeft)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        if (transform.position.x < left.position.x)
        {
           goLeft = !goLeft;
        }

        if (transform.position.x > right.position.x)
        {
            goLeft = !goLeft;
        }
    }
}
