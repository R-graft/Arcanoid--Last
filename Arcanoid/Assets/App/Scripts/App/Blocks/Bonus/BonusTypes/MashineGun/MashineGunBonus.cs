using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashineGunBonus :Bonus
{
    [Header("config")]
    public int bulletsPoolSize = 40;

    public int bulletsCount = 20;

    public float offsetX = 1f;

    public float reloadTime = 0.3f;

    public float disableHold = 2f;

    [Header("components")]
    [SerializeField] private Bullet _bulletPrefab;

    private BlocksDamageHandler _damageHandler;

    private BulletPool<Bullet> _bulletPool;

    public Action OnRemove;

    public override void Init()
    {
        _damageHandler = LevelContext.Instance.GetSystem<BlocksDamageHandler>();

        _bulletPool = new BulletPool<Bullet>(new BulletFactory<Bullet>(_bulletPrefab, _boostParent, _damageHandler, OnRemove), _boostParent);

        CreateBullets(bulletsPoolSize);
    }

    public override void Apply()
    {
        StartCoroutine(Shooting());
    }

    public override void Remove()
    {
        StopAllCoroutines();

        OnRemove?.Invoke();

        transform.parent = _boostParent;

        transform.localPosition = Vector3.zero;
    }

    private IEnumerator Shooting()
    {
        int count = bulletsCount;

        while (count > 0)
        {
            var bullet1 = _bulletPool.GetObject();

            bullet1.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y);

            var bullet2 = _bulletPool.GetObject();

            bullet2.transform.position = new Vector2(transform.position.x - offsetX, transform.position.y);

            count--;

            yield return new WaitForSeconds(reloadTime);

            print(count);
        }

        yield return new WaitForSeconds(disableHold);

        Remove();
    }

    private void CreateBullets(int poolCount)
    {
        var startPool = new List<Bullet>();

        for (int i = 0; i < poolCount; i++)
        {
            var newBullet = _bulletPool.GetObject();

            startPool.Add(newBullet);
        }

        foreach (var item in startPool)
        {
            _bulletPool.ReturnObject(item);
        }
    }
}
