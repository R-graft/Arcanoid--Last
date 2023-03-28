using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashineGunBonus :Bonus
{
    [Header("config")]

    public int bulletsCount = 10;

    public float offsetX = 1f;

    public float reloadTime = 0.3f;

    public float disableHold = 2f;

    [Header("components")]
    private BulletPool<Bullet> _bulletPool;

    private List<Bullet> _bullets;

    public Action OnRemove;

    public override void Init()
    {
        _bulletPool = LevelContext.Instance.GetSystem<SpawnSystem>().BulletPool;
    }

    public override void Apply()
    {
        StartCoroutine(Shooting());
    }

    public override void Remove()
    {
        StopAllCoroutines();

        foreach (Bullet bullet in _bullets)
        {
            _bulletPool.ReturnObject(bullet);
        }

        _bullets.Clear();

        transform.parent = _boostParent;

        transform.localPosition = Vector3.zero;
    }

    private IEnumerator Shooting()
    {
        _bullets = new List<Bullet>();

        int count = bulletsCount;

        while (count > 0)
        {
            var bullet1 = _bulletPool.GetObject();
            var bullet2 = _bulletPool.GetObject();

            _bullets.Add(bullet1);
            _bullets.Add(bullet2);

            bullet1.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y);
            bullet2.transform.position = new Vector2(transform.position.x - offsetX, transform.position.y);

            count--;

            yield return new WaitForSeconds(reloadTime);
        }

        yield return new WaitForSeconds(disableHold);

        Remove();
    }
}
