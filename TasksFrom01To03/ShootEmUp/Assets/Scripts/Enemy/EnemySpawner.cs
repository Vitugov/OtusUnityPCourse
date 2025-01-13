using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private CoroutineManager _coroutineManager;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private int _maxActiveEnemyCount = 8;

        private ICoroutineHandler _spawnerCoroutine;

        private void Start()
        {
            RunSpawner();
        }

        public void RunSpawner()
        {
            var coroutineLogic = new ConditionalCoroutineLogic<EnemyManager>(predicate, 1f, _enemyManager.SpawnEnemy, false);
            _spawnerCoroutine = _coroutineManager.GetCoroutineHandler(coroutineLogic, _enemyManager);
            _coroutineManager.StartCoroutine(_spawnerCoroutine);

            bool predicate(EnemyManager enemyManager) => enemyManager.ActiveEnemyCount < _maxActiveEnemyCount;
        }

        public void StopSpawner()
        {
            if (_spawnerCoroutine != null)
            {
                _spawnerCoroutine.Stop();
                _spawnerCoroutine = null;
            }
        }
    }
}
