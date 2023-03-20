using UnityEngine;

public class GameProgressHandler : MonoBehaviour, IGameHandler
{
    private EnergyCounter _energy;

    private PackDataController _packsData;

    private LevelController _levelController;

    public void SetHandler(LevelController controller)
    {
        _levelController = controller;
    }

    public void InitLevelProgress(EnergyCounter energy, PackDataController packs)
    {
        _energy = energy;

        _packsData = packs;

        _energy.LoadLevel();
    }

    public void SetStart()
    {
        
    }

    public void SetWin()
    {
        _energy.LevelPass();

        _packsData.LevelPass();
    }

    public void SetPause()
    {
       
    }

    public void SetOver()
    {
        _energy.LoadLevel();
    }

    public void SetLose()
    {
       
    }

    public void SetRestart()
    {
        _energy.LoadLevel();
    }
}
