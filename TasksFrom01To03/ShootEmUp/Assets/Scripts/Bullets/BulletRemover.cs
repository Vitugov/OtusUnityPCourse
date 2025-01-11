using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public sealed class BulletRemover
    {
        private readonly HashSet<Bullet> _bulletsToRemove;

        private readonly Action<Bullet> _removeBulletAction;

        public BulletRemover(Action<Bullet> removeBulletAction)
        {
            _removeBulletAction = removeBulletAction;
            _bulletsToRemove = new();
        }

        public void AddToRemoveSet(Bullet bullet)
        {
            _bulletsToRemove.Add(bullet);
        }

        public void AddToRemoveSet(IEnumerable<Bullet> bulletsToRemove)
        {
            foreach (var bullet in bulletsToRemove)
            {
                AddToRemoveSet(bullet);
            }
        }

        public void RemoveBulletsInSet()
        {
            foreach (var bullet in _bulletsToRemove)
            {
                _removeBulletAction(bullet);
            }
            _bulletsToRemove.Clear();
        }
    }
}
