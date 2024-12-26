using UnityEngine;


namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private BulletConfig _bulletConfig;
        private IBulletSpawner _bulletManager;

        private Vector2 Position => _firePoint.position;
        private Quaternion Rotation => _firePoint.rotation;

        public void Initialize(IBulletSpawner bulletManager)
        {
            _bulletManager = bulletManager;
        }

        public void Fire(Vector2 direction)
        {
            BulletArgs bulletArgs = GetBulletArgs(direction);
            _bulletManager.CreateBullet(bulletArgs);
        }

        public void Fire(Transform target)
        {
            var direction = GetDirection(target.position);
            Fire(direction);
        }

        public void Fire()
        {
            var direction = Rotation * Vector2.up;
            Fire(direction);
        }

        private BulletArgs GetBulletArgs(Vector2 direction) => new(_bulletConfig, Position, direction);
        private Vector2 GetDirection(Vector2 targetPosition) => (targetPosition - Position).normalized;
    }
}