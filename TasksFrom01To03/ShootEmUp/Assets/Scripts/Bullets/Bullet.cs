using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> BulletWorkIsDone;

        [SerializeField] private NewMoveComponent _moveComponent;
        [SerializeField] private MoveInDirectionComponent _moveInDirectionComponent;
        [SerializeField] private OutOfBoundsNotifier2 _outOfBoundsNotifier;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TeamComponent _teamComponent;
        [SerializeField] private DamagerComponent _damagerComponent;

        public void Initialize(BulletArgs args, LevelBounds levelBounds)
        {
            SetPosition(args.Position);
            SetSpeed(args.Config.Speed);
            SetDirection(args.Direction);
            SetPhysicsLayer((int)args.Config.PhysicsLayer);
            SetTeam(args.Config.IsPlayer);
            SetColor(args.Config.Color);
            SetDamage(args.Config.Damage);
            _outOfBoundsNotifier.Initialize(levelBounds);
            _outOfBoundsNotifier.OutOfBounds += InvokeBulletWorkIsDone;

        }

        public void Tick()
        {
            _moveInDirectionComponent.Tick();
            _outOfBoundsNotifier.Tick();
        }

        public void DeInitialize()
        {
            _outOfBoundsNotifier.OutOfBounds -= InvokeBulletWorkIsDone;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _damagerComponent.DealDamage(collision.gameObject);
            InvokeBulletWorkIsDone();
        }

        private void InvokeBulletWorkIsDone() => BulletWorkIsDone?.Invoke(this);

        private void SetSpeed(float speed) => _moveComponent.Speed = speed;
        private void SetDirection(Vector2 direction) => _moveInDirectionComponent.Initialize(direction);
        private void SetPhysicsLayer(int physicsLayer) => gameObject.layer = physicsLayer;
        private void SetPosition(Vector3 position) => transform.position = position;
        private void SetColor(Color color) => _spriteRenderer.color = color;
        private void SetDamage(int damage) => _damagerComponent.SetDamage(damage);
        private void SetTeam(bool isPlayer) => _teamComponent.IsPlayer = isPlayer;
    }
}