using System.Linq;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyInitializer _enemyInitializer;
        [SerializeField] private EnemyPoolInstancer _poolInstancer;

        private Pool<Enemy> _enemyPool;

        public int ActiveEnemyCount => _enemyPool.ActiveObjectsCount;

        private void Awake()
        {
            _enemyPool = _poolInstancer.GetPool();
        }

        public void SpawnEnemy()
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

        public void UnspawnAll()
        {
            var activeEnemies = _enemyPool.GetActiveObjects().ToArray();
            foreach (var enemy in activeEnemies)
            {
                UnspawnEnemy(enemy);
            }
        }
    }
}