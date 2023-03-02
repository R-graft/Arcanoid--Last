using UnityEngine;
using UnityEngine.UI;

public class AudioButtonSettings : MonoBehaviour
{
    [SerializeField]
    private Sprite _on;

    [SerializeField]
    private Sprite _off;

    public void SetMusicEnable(Image _buttonImage)
    {
        AudioController.Instance.MusicHandle();

        _buttonImage.sprite = AudioController.Instance.GetMusicValue() ? _on : _off;
    }

    public void SetSoundsEnable(Image _buttonImage)
    {
        AudioController.Instance.SoundHandler();

        _buttonImage.sprite = AudioController.Instance.GetSoundValue() ? _on : _off;
    }

    public void SetStartButtonsImages()
    {

    }
}
