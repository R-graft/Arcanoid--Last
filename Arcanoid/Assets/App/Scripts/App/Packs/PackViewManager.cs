using UnityEngine;

public class PackViewManager : MonoBehaviour
{
    [SerializeField] private PacksData _packs;

    [SerializeField] private PackView[] _packViews;

    [SerializeField] private Sprite _closedPackIcon;

    [SerializeField] private Sprite _closedPackBackground;

    [SerializeField] private string _closedPackTitle;



    [SerializeField] private RectTransform _content;

    [SerializeField] private Color _openColor;
    [SerializeField] private Color _closeColor;
    [SerializeField] private Color _endedColor;

    private EnergyCounter _energy;

    private PackDataController _packsDataController;

    public void Init()
    {
        _energy = ProjectContext.Instance.GetService<EnergyCounter>();

        _packsDataController = ProjectContext.Instance.GetService<PackDataController>();

        SetPacksView();
    }

    public void SetPacksView()
    {
        for (int i = 0; i < _packViews.Length; i++)
        {
            if (_packs.packsModels[i].packIndex == _packViews[i].packIndex)
            {
                SetInterface(_packs.packsModels[i], _packViews[i]);
            }
        }
    }

    public void SetInterface(Pack packModel, PackView pack)
    {
        pack.packTitle.text = packModel.isOpen ? packModel.title : _closedPackTitle;

        pack.packIcon.sprite = packModel.isOpen ? packModel.sprite : _closedPackIcon;

        pack.currentLevel.text = packModel.EndedLevel.ToString();

        pack.LevelsInPack.text = (packModel.finishLevel - packModel.startLevel + 1).ToString();

        pack.packBackground.sprite = packModel.isOpen ? pack.packBackground.sprite : _closedPackBackground;

        SetColors(packModel, pack);

        if (packModel.isOpen)
            pack.packButton.SetDownAction(() => SetCurrentPack(pack.packIndex), true);

    }
    private void SetColors(Pack packModel, PackView pack)
    {
        if (packModel.isEnded)
        {
            pack.packBackground.color = _endedColor;

            pack.packFrame.color = _endedColor;
        }
        else 
        {
            pack.packBackground.color = packModel.isOpen ? _openColor : _closeColor;

            pack.packFrame.color = packModel.isOpen ? _openColor : _closeColor;
        }
    }
    
    public void SetCurrentPack(int index)
    {
        if (_energy.GetGameAsses())
        {
            _packsDataController.SetLevelFrowView(index);

            ScenesManager.Instance.LoadScene(SCENELIST.GameScene);
        }
    }
}

