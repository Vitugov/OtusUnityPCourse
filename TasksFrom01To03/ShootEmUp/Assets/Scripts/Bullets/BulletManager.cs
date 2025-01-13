using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletManager : MonoBehaviour, IResettable, IBulletSpawner
    {
        [SerializeField] private BulletPoolInstancer _bulletPoolInstancer;
        [SerializeField] private CoroutineManager _coroutineManager;
        [SerializeField] private LevelBounds _levelBounds;

        private Pool<Bullet> _bulletPool;
        private HashSet<Bullet> _initializedBullets;

        private void Awake()
        {
            _bulletPool = _bulletPoolInstancer.GetPool();
            _initializedBullets = new HashSet<Bullet>();
        }

        public void SpawnBullet(BulletConfig config, BulletArgs args)
        {
            var bullet = _bulletPool.Get();
            InitializeIfNeeded(bullet);
            bullet.Setup(args, config);
            bullet.BulletWorkIsDone += RemoveBullet;
        }

        void IResettable.Reset()
        {
            RemoveAllBullets();
        }

        private void RemoveBullet(Bullet bullet)
        {
            bullet.BulletWorkIsDone -= RemoveBullet;
            bullet.Stop();
            _bulletPool.Release(bullet);
        }

        private void RemoveAllBullets()
        {
            var activeBullets = _bulletPool.GetActiveObjects().ToArray();
            foreach (var bullet in activeBullets)
            {
                RemoveBullet(bullet);
            }
        }

        private void InitializeIfNeeded(Bullet bullet)
        {
            if (!_initializedBullets.Contains(bullet))
            {
                _initializedBullets.Add(bullet);
                bullet.Initialize(_coroutineManager, _levelBounds);
            }
        }
    }
}

