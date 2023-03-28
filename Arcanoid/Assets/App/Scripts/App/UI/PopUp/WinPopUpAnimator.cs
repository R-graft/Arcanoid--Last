using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPopUpAnimator : MonoBehaviour
{
    [SerializeField] private ButtonElement _continue;

    [SerializeField] private ParticleSystem _emitter;

    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _levelsInPack;

    [SerializeField] private TextMeshProUGUI _levelName;

    [SerializeField] private Transform _title;
    [SerializeField] private Image _nameContour;
                            
    [SerializeField] private Transform _bigRay;
    [SerializeField] private Transform _smallRay;

    [SerializeField] private RectTransform _levelCountParent;

    [SerializeField] private Transform _iconTransform;

    [SerializeField] private Image _icon;
    [SerializeField] private Transform _iconParent;

    [SerializeField] private EnergyBarCounter _bar;

    private EnergyCounter _energy;

    private Sequence _rotator;

    public void AnimateProgress(GameWinPopUp popUp)
    {
        _energy ??= ProjectContext.Instance.GetService<EnergyCounter>();

        _emitter.Play();

        SetStartState();

        SetOldProgress(popUp);

        NameAnimate(popUp);

        AnimateRays();
    }

    public void StopAnimate()
    {
        _emitter.Stop();

        _emitter.Clear();

        _rotator.Kill();
    }
    private void SetOldProgress(GameWinPopUp popUp)
    {
        _continue.transform.localScale = Vector3.zero;

        _level.text = popUp.oldLevel.ToString();
        _levelsInPack.text = popUp.oldMaxLevel.ToString();

        _icon.sprite = popUp.oldSprite;

        _levelName.text = popUp.oldName.ToString();
    }
    
    private void SetStartState()
    {
        _bar.transform.localPosition = new Vector2(0, 800);

        _iconParent.localPosition = new Vector2(-1500,0);

        _levelCountParent.transform.localPosition = new Vector2(0, -1200);

        _title.localScale = Vector2.zero;

        _smallRay.transform.localScale = Vector2.zero;
        _bigRay.transform.localScale = Vector2.zero;

        _nameContour.transform.localScale = Vector2.zero;

        _nameContour.DOFade(1, 0);
    }
    private void NameAnimate(GameWinPopUp popUp)
    {
        DOTween.Sequence().AppendInterval(0.5f).Append(_title.DOScale(new Vector2(1.15f, 1.15f), 0.3f)).
             Append(_title.DOScale(Vector2.one, 0.3f))
            .InsertCallback(1, () => AnimateIcon(popUp));
    }

    private void AnimateIcon(GameWinPopUp popUp)
    {
        var iconSequence = DOTween.Sequence().Append(_iconParent.DOMoveX(0, 0.3f)).
            AppendCallback(() => GetRays()).
            InsertCallback(0,() => AnimateLevelCount(popUp)).
            AppendInterval(0.3f).
            AppendCallback(() => AnimateBar());
        

        if (popUp.oldSprite.name != popUp.newSprite.name)
        {
            iconSequence.Append(_icon.DOFade(0.2f, 1)).
                AppendCallback(() => _icon.sprite = popUp.newSprite).
                Append(_icon.DOFade(1, 1));
        }
    }

    private void AnimateRays()
    {
        _rotator = DOTween.Sequence().Append(_smallRay.DORotate(Vector3.forward * 360, 30, RotateMode.FastBeyond360)).
            Insert(0, _bigRay.DORotate(Vector3.forward * -360, 30, RotateMode.FastBeyond360)).SetLoops(-1).SetTarget(_smallRay.gameObject);
    }

    private void GetRays()
    {
        DOTween.Sequence().Append(_smallRay.DOScale(Vector2.one, 1)).Insert(0, _bigRay.DOScale(Vector2.one, 1));
    }

    private void AnimateLevelCount(GameWinPopUp popUp)
    {
        DOTween.Sequence().
            Append(_levelCountParent.DOAnchorPosY(-175, 0.5f)).
        InsertCallback(1, () => _level.text = popUp.newLevel.ToString()).
        InsertCallback(1, () => _levelsInPack.text = popUp.newMaxLevel.ToString());
    }
    
    private void AnimateBar()
    {
        DOTween.Sequence().AppendCallback(() => _energy.LevelPass()).
            Append(_bar.transform.DOMoveY(5, 0.1f)).
            
            InsertCallback(0, () => _bar.IncreaseEffect(null)).
            Insert(0, _bar.transform.DOScale(new Vector2(1.3f, 1.3f), 0.3f)).
            Append(_bar.transform.DOScale(Vector2.one, 0.3f)).
            Insert(1, _continue.transform.DOScale(new Vector2(1f, 1f), 0.3f));
    }
}

