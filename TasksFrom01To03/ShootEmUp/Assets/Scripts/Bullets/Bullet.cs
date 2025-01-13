using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> BulletWorkIsDone;

        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private MoveInDirectionComponent _moveInDirectionComponent;
        [SerializeField] private OutOfBoundsNotifier _outOfBoundsNotifier;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TeamComponent _teamComponent;
        [SerializeField] private DamagerComponent _damagerComponent;

        private LevelBounds _levelBounds;

        public void Initialize(CoroutineManager coroutineManager, LevelBounds levelBounds)
        {
            _levelBounds = levelBounds;
            _moveInDirectionComponent.Initialize(coroutineManager);
            _outOfBoundsNotifier.Initialize(coroutineManager);
        }

        public void Setup(BulletArgs args, BulletConfig config)
        {
            SetPosition(args.Position);
            SetSpeed(config.Speed);
            SetPhysicsLayer((int)config.PhysicsLayer);
            SetColor(config.Color);
            SetTeam(config.IsPlayer);
            SetDamage(config.Damage);

            _moveInDirectionComponent.MoveToDirection(args.Direction);
            _outOfBoundsNotifier.StartNotifier(_levelBounds);
            _outOfBoundsNotifier.OutOfBounds += InvokeBulletWorkIsDone;
        }

        public void Stop()
        {
            _moveInDirectionComponent.Stop();
            _outOfBoundsNotifier.Stop();
            _outOfBoundsNotifier.OutOfBounds -= InvokeBulletWorkIsDone;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _damagerComponent.DealDamage(collision.gameObject);
            InvokeBulletWorkIsDone();
        }

        private void InvokeBulletWorkIsDone() => BulletWorkIsDone?.Invoke(this);

        private void SetPosition(Vector3 position) => transform.position = position;
        private void SetSpeed(float speed) => _moveComponent.Speed = speed;
        private void SetPhysicsLayer(int physicsLayer) => gameObject.layer = physicsLayer;
        private void SetColor(Color color) => _spriteRenderer.color = color;
        private void SetDamage(int damage) => _damagerComponent.SetDamage(damage);
        private void SetTeam(bool isPlayer) => _teamComponent.IsPlayer = isPlayer;
    }
}