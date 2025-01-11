using UnityEngine;


namespace ShootEmUp
{
    public sealed class EnemyInitializer : MonoBehaviour
    {
        [SerializeField] private BulletManager _bulletManager;
        [SerializeField] private EnemyPositionsProvider _enemyPositionsProvider;
        [SerializeField] private GameObject _character;
        [SerializeField] private CoroutineManager _coroutineManager;

        public void Initialize(Enemy enemy)
        {
            var spawnPosition = _enemyPositionsProvider.Spawn.GetRandomItem();
            var attackPosition = _enemyPositionsProvider.Attack.GetAndLock(enemy.gameObject);
            enemy.Initialize(_coroutineManager, _bulletManager, _character, spawnPosition, attackPosition);
        }

        public void DeInitialize(Enemy enemy)
        {
            _enemyPositionsProvider.Attack.Release(enemy.gameObject);
            enemy.DeInitialize();
        }
    }
}
