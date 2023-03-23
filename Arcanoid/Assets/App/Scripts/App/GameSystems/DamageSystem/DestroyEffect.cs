using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;

    private Transform _parent;

    public void Construct(Transform parent, Color _effectColor)
    {
        _parent = parent;

        var main = _destroyEffect.main;

        main.startColor = _effectColor;
    }

    public void ApplyDestroy()
    {
        gameObject.transform.parent = null;

        _destroyEffect.Play();
    }

    private void OnParticleSystemStopped()
    {
        gameObject.transform.parent = _parent;

        transform.localPosition = Vector3.zero;
    }
}
