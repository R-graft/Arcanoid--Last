using System;
using System.Collections;
using UnityEngine;

public class MashineGunBonus :Bonus
{
    [Header("config")]
    public int bulletsPoolSize = 20;

    public int bulletsCount = 10;

    public float offsetX = 0.5f;

    public float offsetY = 0f;

    public float reloadTime = 0.3f;

    public float disableHold = 2f;

    [Header("components")]
    [SerializeField] private Bullet _bulletPrefab;

    private BlocksDamageHandler _damageHandler;

    private BulletPool<Bullet> _bulletPool;

    //private PlatformController _platform;

    public Action OnRemove;

    public override void Init()
    {
        _damageHandler = LevelContext.Instance.GetSystem<BlocksDamageHandler>();

        _bulletPool = new BulletPool<Bullet>(null, _boostParent);

        //_platform = LevelContext.Instance.GetSystem<PlatformController>();

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
            //var position = _platform.GetTransform().position;

            var bullet1 = _bulletPool.GetObject();

            bullet1.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y + offsetY);

            var bullet2 = _bulletPool.GetObject();

            bullet2.transform.position = new Vector2(transform.position.x - offsetX, transform.position.y + offsetY);

            count--;

            yield return new WaitForSeconds(reloadTime);
        }

        yield return new WaitForSeconds(disableHold);

        Remove();
    }

    private void CreateBullets(int poolCount)
    {
        for (int i = 0; i < poolCount; i++)
        {
            var newBullet = Instantiate(_bulletPrefab);

            newBullet.Construct(_damageHandler, _bulletPool, OnRemove);

            _bulletPool.ReturnObject(newBullet);
        }
    }
}
