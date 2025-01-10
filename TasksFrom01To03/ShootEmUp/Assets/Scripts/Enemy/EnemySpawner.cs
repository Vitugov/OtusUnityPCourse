using UnityEngine;


namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private int _maxActiveEnemyCount = 8;

        private ConditionalCoroutineHandler _spawnerCoroutine;

        private void Start()
        {
            RunSpawner();
        }

        public void RunSpawner()
        {
            _spawnerCoroutine = new ConditionalCoroutineHandler(predicate, 1f, _enemyManager.SpawnEnemy, false);
            _spawnerCoroutine.Start(this, gameObject);

            bool predicate(GameObject obj) => _enemyManager.ActiveEnemyCount < _maxActiveEnemyCount;
        }

        public void StopSpawner()
        {
            if (_spawnerCoroutine != null)
            {
                _spawnerCoroutine.Stop(this);
                _spawnerCoroutine = null;
            }
        }
    }
}
