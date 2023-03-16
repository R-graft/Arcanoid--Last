using UnityEngine;

public class GamePanelController : MonoBehaviour
{
    [Header("config")]
    public int startLivesCount = 3;

    public int maxLivesCount = 5;

    [SerializeField] private GamePanelView _interface;

    public LevelController controller;

    private int _livesCount;

    private float _progressStep;

    private PackDataController _packsData;

    public void Init()
    {
        _packsData = ProjectContext.Instance.GetService<PackDataController>();

        _interface.Init(_packsData);

        _interface.RefreshPanel();

        ReStart();
    }
    public void ReStart()
    {
        _livesCount = startLivesCount;

        _interface.SetStartLives(_livesCount);
    }

    public void Lose()
    {
        _livesCount--;

        if (_livesCount == 0)
        {
            controller.GameOver();
        }

        _interface.RemoveLife();
    }
    
    public void Win()
    {
        _interface.RefreshPanel();
    }

    private void LevelProgressCounter()
    {

    }
    private void SetProgressStep(int count) => _progressStep = 1 / (float)count;

    private void SetLevelProgress() => _interface.SetProgress(_progressStep);
}
