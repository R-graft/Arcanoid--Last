using UnityEngine;

public class PackViewManager : MonoBehaviour
{
    [SerializeField]
    private PackView[] _packViews;

    [SerializeField]
    private Sprite _closedPackIcon;

    [SerializeField]
    private Sprite _closedPackBackground;

    [SerializeField]
    private RectTransform _content;

    public void Init()
    {
        SetPacksView();
    }

    public void SetInterface(Pack packModel, PackView pack)
    {
        pack.packTitle.text = packModel.title;

        pack.packIcon.sprite = packModel.isOpen ? packModel.sprite : _closedPackIcon;

        pack.currentLevel.text = packModel.EndedLevel.ToString();

        pack.LevelsInPack.text = (packModel.finishLevel - packModel.startLevel + 1).ToString();

        pack.packBackground.sprite = packModel.isOpen ? pack.packBackground.sprite : _closedPackBackground;

        if (packModel.isOpen)
            pack.packButton.SetDownAction(() => SetCurrentPack(pack.packIndex), true);

    }

    public void SetPacksView()
    {
        if (!GameProgressController.Instance)
            return;
        
        var packModels = GameProgressController.Instance.PacksController.PacksModels;

        for (int i = 0; i < packModels.Length; i++)
        {
            if (packModels[i].packIndex == _packViews[i].packIndex)
            {
                SetInterface(packModels[i], _packViews[i]);
            }
        }
    }
    public void SetCurrentPack(int index)
    {
        if (GameProgressController.Instance.GameAccess)
        {
            GameProgressController.Instance.SetDataFromVeiw(index);

            ScenesManager.Instance.LoadScene(SCENELIST.GameScene);
        }
    }

    private void SetScrollContentPosition(int index)
    {
        var contentRectHeight = _content.rect.height;

        var heightStep = contentRectHeight / _packViews.Length;

        _content.localPosition += new Vector3(_content.localPosition.x, heightStep * index, _content.localPosition.z);
    }
}
