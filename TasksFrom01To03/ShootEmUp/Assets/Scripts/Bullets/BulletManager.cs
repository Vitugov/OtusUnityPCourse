using UnityEngine;


namespace ShootEmUp
{
    public sealed class BulletManager : MonoBehaviour, IBulletSpawner
    {
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private BulletPoolInstancer _bulletPoolInstancer;

        private Pool<Bullet> _bulletPool;

        private void Awake()
        {
            _bulletPool = _bulletPoolInstancer.GetPool();
        }

        public void CreateBullet(BulletArgs args)
        {
            var bullet = _bulletPool.Get();
            bullet.Initialize(args, _levelBounds);
            bullet.BulletWorkIsDone += RemoveBullet;
        }

        private void RemoveBullet(Bullet bullet)
        {
            bullet.BulletWorkIsDone -= RemoveBullet;
            bullet.DeInitialize();
            _bulletPool.Release(bullet);
        }

        private void RemoveAllBullets()
        {
            var activeBullets = _bulletPool.GetActiveObjects();
            foreach (var bullet in activeBullets)
            {
                RemoveBullet(bullet);
            }
        }
    }
}

