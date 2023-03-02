using UnityEngine;
using DG.Tweening;

[System.Serializable]
public abstract class Block : MonoBehaviour, IPoolable, IAnimatedElement
{
    [Header("controller")]
    public int poolSize;
    [HideInInspector] public (int x, int y) selfGridIndex;

    [Header("model")]
    public BlocksList blockId;

    public Collider2D _collider;

    public int HealthCount { get; set; }

    [Header("view")]
    public SpriteRenderer _blockSprite;

    [SerializeField] private BlockSounds _sound;

    [HideInInspector] public BlocksSystem _blocksSystem;

    public void SetStartSize(Vector2 size)
    {
        transform.localScale = size;
    }
    public virtual void InAnimation()
    {
        _sound.GetSoundState();

        _sound.GetAwakeSound();

        DOTween.To(()=> _blockSprite.size, x => _blockSprite.size = x, Vector2.one, 0.2f);
    }

    public virtual void OutAnimation()
    {
        _sound.GetDestroySound();

        DOTween.To(() => _blockSprite.size, x => _blockSprite.size = x, new Vector2(1.2f, 1.4f), 0.3f).OnComplete(()=> gameObject.SetActive(false));
    }

    public virtual void InDamage(int damageValue)
    {
        _sound.GetDamageSound();

        DOTween.Sequence().
        Append(DOTween.To(() => _blockSprite.size, x => _blockSprite.size = x, new Vector2(0.9f, 0.9f), 0.1f))
        .Append(DOTween.To(() => _blockSprite.size, x => _blockSprite.size = x, new Vector2(1f, 1f), 0.1f)).SetLoops(2);
    }

    public virtual void InDestroy() => _blocksSystem.BlockRemove(selfGridIndex);
}

public interface IDamageable
{
    public int HealthCount { get; set; }
    public void InDestroy();
    public void InDamage(int damageValue);
}



