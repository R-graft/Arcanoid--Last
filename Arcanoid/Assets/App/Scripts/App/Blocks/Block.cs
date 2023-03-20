using UnityEngine;

[System.Serializable]
public abstract class Block : BasePoolObject
{
    [SerializeField] protected SpriteRenderer _renderer;

    [SerializeField] protected Collider2D _collider;

    [SerializeField] protected DamageEffect _damageEffect;

    protected string _blockId;

    protected Vector2 _selfGridIndex;

    protected int _startHealth;

    public bool nonDamageable;

    public virtual void Construct(string id, int health, Sprite sprite)
    {
        _blockId = id;

        _startHealth = health;

        _renderer.sprite = sprite;
    }

    public abstract void RefreshBlock();
    public void SetStartSize(Vector2 size) => transform.localScale = size;

    public void SetGridIndex(Vector2 index) => _selfGridIndex = index;

    public string GetId() => _blockId;
}