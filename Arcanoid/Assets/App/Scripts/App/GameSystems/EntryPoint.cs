using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [Header("instances")]
    [SerializeField] private GameProgressController _gameProgress;
    [SerializeField] private ScenesManager _scenesManager;
    [SerializeField] private Inputs _inputs;
    [SerializeField] private ScreenSizeHandler _screen;
    [SerializeField] private AudioController _audio;

    [Header("components")]
    private Camera _m_Camera;

    private static bool _isInitialized;
    private void Awake()
    {
        if (!_isInitialized)
        {
            _gameProgress = Instantiate(_gameProgress);
            _gameProgress.Init();

            _scenesManager = Instantiate(_scenesManager);
            _scenesManager.Init();

            _inputs = Instantiate(_inputs);
            _inputs.Init();

            _screen = Instantiate(_screen);
            _screen.Init();

            _audio = Instantiate(_audio);
            _audio.Init();

            _inputs.TurnOn(true);

            _isInitialized = true;
        }
    }
}
