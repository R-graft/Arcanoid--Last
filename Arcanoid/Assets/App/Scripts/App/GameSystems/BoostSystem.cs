using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSystem : MonoBehaviour
{
    private class BonusCoroutines
    {
        public Bonus bonus;

        public Coroutine coroutine;

        public BonusCoroutines(Bonus _bonus, Coroutine _coroutine)
        {
            bonus = _bonus;
            coroutine = _coroutine;
        }
    }

    private Dictionary<Type, BonusCoroutines> _activeBonuses = new Dictionary<Type, BonusCoroutines>();

    public static Action<Bonus> OnBonusActivation;

    public void StopSystem()
    {
        StopAllBonuses();

        _activeBonuses = new Dictionary<Type, BonusCoroutines>();
    }
    
    private void BonusControl(Bonus currentBonus)
    {
        var bonusType = currentBonus.GetType();

        if (_activeBonuses.ContainsKey(bonusType))
        {
            StopCoroutine(_activeBonuses[bonusType].coroutine);

            _activeBonuses[bonusType].bonus.Remove();

            Destroy(_activeBonuses[bonusType].bonus.gameObject);

            _activeBonuses[bonusType].bonus = currentBonus;

            _activeBonuses[bonusType].coroutine = ActivateBonus(currentBonus, currentBonus.time);
        }

        else
        {
            _activeBonuses.Add(bonusType, new BonusCoroutines(currentBonus, ActivateBonus(currentBonus, currentBonus.time)));
        }
    }

    private Coroutine ActivateBonus(Bonus bonus, float time)
    {
        bonus.gameObject.transform.SetParent(transform);

        return StartCoroutine(BonusTimer(bonus, time));
    }

    private IEnumerator BonusTimer(Bonus bonus, float time)
    {
        bonus.Apply();
        
        while (time > 0)
        {
            yield return new WaitForFixedUpdate();
            
            time -= Time.fixedDeltaTime;
        }

        bonus.Remove();

        Destroy(bonus.gameObject);

        _activeBonuses.Remove(bonus.GetType());
    }

    private void StopAllBonuses()
    {
        StopAllCoroutines();

        if (_activeBonuses != null)
        {
            foreach (var item in _activeBonuses.Values)
            {
                Destroy(item.bonus.gameObject);

                item.bonus.Remove();
            }
            _activeBonuses.Clear();
        }
    }

    private void OnEnable()
    {
        OnBonusActivation += BonusControl;
    }
    private void OnDisable()
    {
        OnBonusActivation -= BonusControl;
    }
}
