using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColoredBlock : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _blocksColors;

    public void SetColor(SpriteRenderer sprite, int healthCount)
    {
        sprite.sprite = _blocksColors[healthCount-1];
    }
}
