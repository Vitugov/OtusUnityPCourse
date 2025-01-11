using System.Linq;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class BulletManager : MonoBehaviour, IBulletSpawner, IReloadable, IPauseable
    {
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private BulletPoolInstancer _bulletPoolInstancer;

        private Pool<Bullet> _bulletPool;
        private BulletRemover _bulletRemover;

        public bool IsPaused { get; set; }

        private void Awake()
        {
            _bulletPool = _bulletPoolInstancer.GetPool();
            _bulletRemover = new BulletRemover(RemoveBullet);
        }

        private void Update()
        {
            if (IsPaused) return;
            _bulletRemover.RemoveBulletsInSet();
            TickAllBullets();
        }

        private void TickAllBullets()
        {
            var activeBullets = _bulletPool.GetActiveObjects();
            foreach (var bullet in activeBullets)
            {
                bullet.Tick();
            }
        }

        public void CreateBullet(BulletArgs args)
        {
            var bullet = _bulletPool.Get();
            bullet.Initialize(args, _levelBounds);
            bullet.BulletWorkIsDone += _bulletRemover.AddToRemoveSet;
        }

        public void Reload()
        {
            RemoveAllBullets();
        }

        private void RemoveBullet(Bullet bullet)
        {
            bullet.BulletWorkIsDone -= _bulletRemover.AddToRemoveSet;
            bullet.DeInitialize();
            _bulletPool.Release(bullet);
        }

        private void RemoveAllBullets()
        {
            var activeBullets = _bulletPool.GetActiveObjects().ToArray();
            _bulletRemover.AddToRemoveSet(activeBullets);
            _bulletRemover.RemoveBulletsInSet();
        }
    }
}

