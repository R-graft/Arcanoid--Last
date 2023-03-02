using UnityEngine;

public class BallSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource _ballAudioSource;

    [SerializeField]
    private AudioClip _touch;

    private bool _enableSound;

    private void Awake()
    {
        _enableSound = AudioController.Instance.GetSoundValue();
    }
    public void GetSoundTouch()
    {
        if (_enableSound)
            _ballAudioSource.PlayOneShot(_touch);
    }
}
