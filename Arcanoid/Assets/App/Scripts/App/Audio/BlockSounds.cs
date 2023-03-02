using UnityEngine;

public class BlockSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource _blockAudioSource;

    [SerializeField]
    private AudioClip _awake;

    [SerializeField]
    private AudioClip _destroy;

    [SerializeField]
    private AudioClip _damage;

    private bool _enableSound;

    public void GetSoundState() => _enableSound = AudioController.Instance.GetSoundValue();

    public void GetAwakeSound()
    {
        if (_enableSound)
            _blockAudioSource.PlayOneShot(_awake);
    }

    public void GetDamageSound()
    {
        if (_enableSound)
            _blockAudioSource.PlayOneShot(_damage);
    }

    public void GetDestroySound()
    {
        if (_enableSound)
            _blockAudioSource.PlayOneShot(_destroy);
    }
}
