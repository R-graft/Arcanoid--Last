using UnityEngine;

[System.Serializable]
public abstract class Block : BasePoolObject
{
    [SerializeField] protected SpriteRenderer _renderer;

    [SerializeField] protected Collider2D _collider;

    [SerializeField] protected DamageEffect _damageEffect;

    [SerializeField] protected DestroyEffect _destroyEffect;

    public Vector2 _selfGridIndex;

    public bool nonDamageable;

    protected string _blockId;

    protected int _startHealth;

    public virtual void Construct(string id, int health, Sprite sprite, Color effectColor)
    {
        _blockId = id;

        _startHealth = health;

        _renderer.sprite = sprite;

        _destroyEffect.Construct(transform, effectColor);
    }

    public abstract void RefreshBlock();

    public void SetStartSize(Vector2 size) => transform.localScale = size;

    public void SetGridIndex(Vector2 index) => _selfGridIndex = index;

    public string GetId() => _blockId;

    public Collider2D GetCollider() => _collider;
}