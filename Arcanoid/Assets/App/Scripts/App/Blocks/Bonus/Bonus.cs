using System;
using System.Collections;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    public float time;

    public abstract void Apply();

    public abstract void Remove();
}
