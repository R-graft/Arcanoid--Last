using UnityEngine;

public class AudioState
{
    private AudioValues _audioValues = new AudioValues();

    private const string AudioKey = "Audio";

    public AudioValues GetAudioValues()
    {
        if (PlayerPrefs.HasKey(AudioKey))
            _audioValues = JsonUtility.FromJson<AudioValues>(PlayerPrefs.GetString(AudioKey));

        else
            Create();

        return _audioValues;
    }

    public void EnableMusic(bool value)
    {
        _audioValues.music = value;
        Save();
    }

    public void EnableSounds(bool value)
    {
        _audioValues.sound = value;
        Save();
    }

    private void Create()
    {
        _audioValues.music = true;

        _audioValues.sound = true;

        Save();
    }

    private void Save()
    {
        string save = JsonUtility.ToJson(_audioValues);

        PlayerPrefs.SetString(AudioKey, save);
    }
}
[System.Serializable]
public class AudioValues
{
    public bool music;

    public bool sound;
}
