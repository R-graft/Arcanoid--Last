using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BonusSystem : GameSystem
{
    private Dictionary<Type, BonusEntity> _activeBonuses;

    public Action OnRestart;

    public override void InitSystem()
    {
        _activeBonuses = new Dictionary<Type, BonusEntity>();
    }

    public override void ReStartSystem() => StopAllBonuses();

    public override void StopSystem()=> StopAllBonuses();

    public void ActivateBonus(Bonus bonus)
    {
        var type = bonus.GetType();

        if (_activeBonuses.ContainsKey(type))
        {
            BonusStop(type);

            _activeBonuses[type] = new BonusEntity(bonus);
        }

        else
        {
            _activeBonuses.Add(type, new BonusEntity(bonus));
        }

        BonusStart(type);
    }

    private void BonusStart(Type startedType)
    {
        StartCoroutine(_activeBonuses[startedType].coroutine);
    }

    private void BonusStop(Type stoppedType)
    {
        var stoppedBonus = _activeBonuses[stoppedType];

        StopCoroutine(stoppedBonus.coroutine);

        if (stoppedBonus.isActive)
        {
            stoppedBonus.bonus.Remove();

            stoppedBonus.isActive = false;
        }
    }

    private void StopAllBonuses()
    {
        foreach (var item in _activeBonuses)
        {
            BonusStop(item.Key);
        }

        OnRestart?.Invoke();
    }
}

public class BonusEntity
{
    public Bonus bonus;

    public IEnumerator coroutine;

    public float time;

    public bool isActive;

    public BonusEntity(Bonus _bonus)
    {
        bonus = _bonus;

        time = _bonus.time;

        coroutine = BonusTimer();
    }

    private IEnumerator BonusTimer()
    {
        isActive = true;

        bonus.Apply();

        while (time > 0)
        {
            yield return new WaitForFixedUpdate();

            time -= Time.fixedDeltaTime;
        }

        bonus.Remove();

        isActive= false;
    }
}
