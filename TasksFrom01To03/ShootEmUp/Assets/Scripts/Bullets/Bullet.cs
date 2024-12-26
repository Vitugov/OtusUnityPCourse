using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> BulletWorkIsDone;

        [SerializeField] private OutOfBoundsNotifier _outOfBoundsNotifier;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TeamComponent _teamComponent;
        [SerializeField] private DamagerComponent _damagerComponent;

        public void Initialize(BulletArgs args, LevelBounds levelBounds)
        {
            SetPosition(args.Position);
            SetVelocity(args.Velocity);
            SetPhysicsLayer((int)args.Config.PhysicsLayer);
            SetTeam(args.Config.IsPlayer);
            SetColor(args.Config.Color);
            SetDamage(args.Config.Damage);
            _outOfBoundsNotifier.InitializeAndStart(levelBounds, () => BulletWorkIsDone(this));
        }

        public void DeInitialize()
        {
            _outOfBoundsNotifier.Cleanup();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _damagerComponent.DealDamage(collision.gameObject);
            BulletWorkIsDone?.Invoke(this);
        }

        private void SetVelocity(Vector2 velocity) => _rigidbody2D.velocity = velocity;
        private void SetPhysicsLayer(int physicsLayer) => gameObject.layer = physicsLayer;
        private void SetPosition(Vector3 position) => transform.position = position;
        private void SetColor(Color color) => _spriteRenderer.color = color;
        private void SetDamage(int damage) => _damagerComponent.SetDamage(damage);
        private void SetTeam(bool isPlayer) => _teamComponent.IsPlayer = isPlayer;
    }
}