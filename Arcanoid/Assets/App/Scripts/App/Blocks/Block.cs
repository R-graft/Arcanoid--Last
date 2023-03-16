using UnityEngine;

[System.Serializable]
public abstract class Block : BasePoolObject
{
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private Collider2D _collider;

    [SerializeField] protected DamageEffect _damageEffect;

    private string _blockId;

    private Vector2 _selfGridIndex;

    protected int _healthCount;

    public bool nonDamageable;

    public void Construct(string id, int health, Sprite sprite)
    {
        _blockId = id;

        _healthCount = health;

        _renderer.sprite = sprite;

        _damageEffect.CreateEffect(transform.position);
    }
    public void SetStartSize(Vector2 size) => transform.localScale = size;

    public void SetGridIndex(Vector2 index) => _selfGridIndex = index;

    public string GetId() => _blockId;
}





