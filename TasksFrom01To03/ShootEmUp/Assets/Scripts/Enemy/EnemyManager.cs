using UnityEngine;


namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyInitializer _enemyInitializer;
        [SerializeField] private EnemyPoolInstancer _poolInstancer;
        [SerializeField] private int _maxActiveEnemyCount = 8;

        private Pool<Enemy> _enemyPool;
        private ConditionHandler _spawnerCoroutine;

        private void Start()
        {
            _enemyPool = _poolInstancer.GetPool();
            RunSpawner();
        }

        private void RunSpawner()
        {
            _spawnerCoroutine = new ConditionHandler(predicate, 1f, SpawnEnemy, false);
            _spawnerCoroutine.Start(this, gameObject);

            bool predicate(GameObject obj) => _enemyPool.ActiveObjectsCount < _maxActiveEnemyCount;
        }

        private void SpawnEnemy()
        {
            var enemy = _enemyPool.Get();
            _enemyInitializer.Initialize(enemy);
            enemy.HpEmpty += UnspawnEnemy;
        }

        private void UnspawnEnemy(Enemy enemy)
        {
            enemy.HpEmpty -= UnspawnEnemy;
            _enemyInitializer.DeInitialize(enemy);
            _enemyPool.Release(enemy);
        }

        private void UnspawnAll()
        {
            var activeEnemies = _enemyPool.GetActiveObjects();
            foreach (var enemy in activeEnemies)
            {
                UnspawnEnemy(enemy);
            }
        }
    }
}