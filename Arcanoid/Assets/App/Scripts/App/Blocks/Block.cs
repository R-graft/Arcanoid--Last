using UnityEngine;
using DG.Tweening;

[System.Serializable]
public abstract class Block : BasePoolObject
{
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private Collider2D _collider;

    public string BlockId { get; private set; }

    private Vector2 _selfGridIndex;

    private int _healthCount;
    // //////////////////////////

    [HideInInspector] public string blockId;

    [HideInInspector] public BlocksSystem _blocksSystem;

    [HideInInspector] public (int x,int y) selfGridIndex;
    public void Construct(string id, int health, Sprite sprite)
    {
        BlockId = id;

        _healthCount = health;

        _renderer.sprite = sprite;
    }
    public override void Return()
    {
        gameObject.SetActive(false);

        base.Return();
    }

    public void SetStartSize(Vector2 size)
    {
        transform.localScale = size;
    }

    public virtual void InDamage(int damage)
    {

    }

    public virtual void InDestroy()
    {

    }
}

public interface IDamageable
{
    public int HealthCount { get; set; }
    public void InDestroy();
    public void InDamage(int damageValue);
}



