using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPopUpAnimator : MonoBehaviour
{
    [SerializeField] private Image _continue;

    [SerializeField] private ParticleSystem _emitter;

    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _levelsInPack;

    [SerializeField] private Transform _title;
                            
    [SerializeField] private Transform _bigRay;
    [SerializeField] private Transform _smallRay;

    [SerializeField] private Image _levelCountParent;

    [SerializeField] private Transform _iconTransform;
    [SerializeField] private Image _icon;

    [SerializeField] private Image _iconParent;
    [SerializeField] private TextMeshProUGUI _galacticName;

    [SerializeField] private EnergyBarCounter _bar;

    [SerializeField] private RectTransform _barTransform;

    private EnergyCounter _energy;

    private Sequence _raysSeq;

    public void AnimateProgress(GameWinPopUp popUp)
    {
        _energy ??= ProjectContext.Instance.GetService<EnergyCounter>();

        _emitter.Play();

        SetStartState();

        SetOldProgress(popUp);

        DOTween.Sequence().
            AppendCallback(() => NameAnimate()).
            InsertCallback(1, () => AnimateBar()).
            InsertCallback(1, () => AnimateIcon(popUp)).
            InsertCallback(2, () => GetRays()).
            InsertCallback(2, () => AnimateLevelCount(popUp)).
            InsertCallback(3, () => AnimateButton());
    }

    public void StopAnimate()
    {
        _emitter.Stop();

        _emitter.Clear();

        _raysSeq.Kill();
    }
    private void SetOldProgress(GameWinPopUp popUp)
    {
        _continue.transform.localScale = Vector3.zero;

        _level.text = popUp.oldLevel.ToString();
        _levelsInPack.text = popUp.oldMaxLevel.ToString();

        _icon.sprite = popUp.oldSprite;

        _galacticName.text = popUp.oldName.ToString();
    }
    
    private void SetStartState()
    {
        _barTransform.localScale = Vector2.zero;

        _iconParent.DOFade(0, 0);
        _icon.DOFade(0, 0);

        _levelCountParent.transform.localScale = Vector2.zero;
        _levelCountParent.DOFade(0, 0);

        _title.localScale = Vector2.zero;
        _galacticName.transform.localScale = Vector2.zero;

        _smallRay.transform.localScale = Vector2.zero;
        _bigRay.transform.localScale = Vector2.zero;

        _continue.transform.localScale = Vector2.zero;
        _continue.DOFade(0, 0);
    }
    private void NameAnimate()
    {
        DOTween.Sequence().AppendInterval(0.5f).Append(_title.DOScale(new Vector2(1.2f, 1.2f), 0.2f)).
             Append(_title.DOScale(Vector2.one, 0.2f));
    }

    private void AnimateIcon(GameWinPopUp popUp)
    {
        var iconSequence = DOTween.Sequence().Insert(1, _iconParent.DOFade(1, 0.5f)).
            Insert(1, _icon.DOFade(1, 0.5f)).
            Insert(1, _galacticName.transform.DOScale(1, 0.5f));

        if (popUp.oldSprite.name != popUp.newSprite.name)
        {
            iconSequence.Append(_icon.transform.DOScale(new Vector2(1.05f, 1.05f), 0.2f)).
                Append(_icon.DOFade(0.2f, 0.2f)).
                AppendCallback(() => _icon.sprite = popUp.newSprite).
                Append(_icon.DOFade(1, 0.2f)).
                InsertCallback(2, () => _level.text = popUp.newLevel.ToString()).
                InsertCallback(2, () => _levelsInPack.text = popUp.newMaxLevel.ToString()).
                Append(_icon.transform.DOScale(Vector2.one, 0.2f));
        }
    }

    private void AnimateLevelCount(GameWinPopUp popUp)
    {
        var oldlevel = popUp.oldLevel +1 > popUp.oldMaxLevel ? popUp.oldMaxLevel : popUp.oldLevel  + 1;

        DOTween.Sequence().
            Append(_levelCountParent.transform.DOScale(Vector2.one, 0.5f)).
            Insert(0, _levelCountParent.DOFade(1, 0.5f)).
            InsertCallback(0, () => _level.text = (oldlevel).ToString()).
            InsertCallback(0, () => _levelsInPack.text = popUp.oldMaxLevel.ToString());
    }

    private void GetRays()
    {
        _raysSeq = DOTween.Sequence().
            Append(_smallRay.DOScale(Vector2.one, 0.5f)).
            Insert(0, _bigRay.DOScale(Vector2.one, 0.5f)).
            Insert(0, _smallRay.DORotate(Vector3.forward * 360, 30, RotateMode.FastBeyond360)).
            Insert(0, _bigRay.DORotate(Vector3.forward * -360, 30, RotateMode.FastBeyond360));

        _raysSeq.SetLoops(-1);
    }

    private void AnimateBar()
    {
        DOTween.Sequence().
            Append(_barTransform.DOScale(new Vector2(1.3f, 1.3f), 0.3f)).
            AppendCallback(() => _energy.LevelPass()).
            InsertCallback(0, () => _bar.IncreaseEffect(null)).
            AppendInterval(0.2f).
            Append(_bar.transform.DOScale(Vector2.one, 0.3f));
            
    }

    private void AnimateButton()
    {
        DOTween.Sequence().
        Append(_continue.transform.DOScale(new Vector2(1f, 1f), 0.4f)).
        Insert(0, _continue.DOFade(1, 0.4f));
    }
}

