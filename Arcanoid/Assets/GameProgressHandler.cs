using UnityEngine;

public class GameProgressHandler : MonoBehaviour, IGameHandler
{
    private EnergyCounter _energy;

    private PackDataController _packsData;

    private LevelController _levelController;

    public void InitController(LevelController controller)
    {
        _levelController = controller;
    }

    public void InitLevelProgress(EnergyCounter energy, PackDataController packs)
    {
        _energy = energy;

        _packsData = packs;
    }

    public void StartGame()
    {
        _energy.LoadLevel();
    }

    public void WinGame()
    {
        _energy.LevelPass();

        _packsData.LevelPass();
    }

    public void PauseGame()
    {
       
    }

    public void RestartGame()
    {
       
    }

    public void LoseGame()
    {
       
    }
}
