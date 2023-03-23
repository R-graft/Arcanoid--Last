using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelAnimator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _emitter;

    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _levelsInPack;

    [SerializeField] private TextMeshProUGUI _levelName;
                            
    [SerializeField] private Transform _bigRay;
    [SerializeField] private Transform _smallRay;

    [SerializeField] private RectTransform _levelCountParent;

    [SerializeField] private Transform _iconTransform;

    [SerializeField] private Image _icon;

    private TextMeshProUGUI _currentLevel;

    private AnimateHandler _animator;

    private Sequence _rotator;

    public void AnimateProgress(GameWinPopUp popUp)
    {
        _emitter.Play();

        SetOldProgress(popUp);

        AnimateRays();

        AnimateLevelCount(popUp);

        AnimateIcon(popUp);
    }

    public void StopAnimate()
    {
        _emitter.Stop();

        _emitter.Clear();

        _rotator.Kill();
    }
    private void SetOldProgress(GameWinPopUp popUp)
    {
        _level.text = popUp.oldLevel.ToString();
        _levelsInPack.text = popUp.oldMaxLevel.ToString();

        _icon.sprite = popUp.oldSprite;

        _levelName.text = popUp.oldName.ToString();
    }
    
    private void AnimateIcon(GameWinPopUp popUp)
    {
        if (popUp.oldSprite.name != popUp.newSprite.name)
        {
            DOTween.Sequence().Append(_icon.DOFade(0.2f, 1)).AppendCallback(() => _icon.sprite = popUp.newSprite).Append(_icon.DOFade(1, 1));
        }
    }

    private void AnimateLevelCount(GameWinPopUp popUp)
    {
        _level.text = popUp.newLevel.ToString();

        _levelsInPack.text = popUp.newMaxLevel.ToString();
    }
    private void AnimateRays()
    {
        _rotator = DOTween.Sequence().Append(_smallRay.DORotate(Vector3.forward * 360, 30, RotateMode.FastBeyond360)).
            Insert(0, _bigRay.DORotate(Vector3.forward * -360, 30, RotateMode.FastBeyond360)).SetLoops(-1).SetTarget(gameObject);
    }
}

