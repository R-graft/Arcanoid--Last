using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashineGunBonus : Bonus
{
    [Header ("config")]
    public int bulletsPoolSize = 10;

    public float offsetX = 0.5f;

    public float offsetY = 0.5f;

    public float reloadTime = 0.3f;

    public float disableHold = 2f;

    [Header("components")]
    [SerializeField] private Bullet _prefab;

    private ObjectPool<Bullet> _bulletPool;

    private List<Bullet> _bullets;

    public override void Apply()
    {
        StartCoroutine(Shooting());
    }

    public override void Remove()
    {
        StopAllCoroutines();

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();

        DestroyBullets();
    }

    private void OnEnable()
    {
        _bullets = new List<Bullet>();

        _bulletPool = new ObjectPool<Bullet>(() => CreateBullet(),
            bullet => bullet.gameObject.SetActive(false),
            bullet => bullet.gameObject.SetActive(true),
            bullet => bullet.gameObject.SetActive(false));

        for (int i = 0; i < bulletsPoolSize; i++)
        {
            _bulletPool.CreatePoolObject();
        }

        BonusEvents.OnResizePlatform.AddListener(OnSetScale);
    }

    private IEnumerator Shooting()
    {
        int count = bulletsPoolSize;

        while (count > 0)
        {
            var position = PlatformController.OnGetTransform.Invoke().position;

            var bullet1 = _bulletPool.Get();

            bullet1.transform.position = new Vector2(position.x + offsetX, position.y + offsetY);

            var bullet2 = _bulletPool.Get();

            bullet2.transform.position = new Vector2(position.x - offsetX, position.y + offsetY);

            count--;

            yield return new WaitForSecondsRealtime(reloadTime);
        }

        yield return new WaitForSecondsRealtime(disableHold);
        Remove();
    }
    private Bullet CreateBullet()
    {
        var newBullet = Instantiate(_prefab, transform);

        newBullet.OnCeateBullet(_bulletPool);

        _bullets.Add(newBullet);

        return newBullet;
    }

    private void DestroyBullets()
    {
        foreach (var item in _bullets)
            Destroy(item.gameObject);
    }

    private void OnSetScale(float value)
    {
        offsetX += value/2;
    }
}
