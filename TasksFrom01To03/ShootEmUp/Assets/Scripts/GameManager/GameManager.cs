using UnityEngine;


namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private BulletManager _bulletManager;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private EnemySpawner _enemySpawner;

        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

        [ContextMenu("Pause Game")]
        public void Pause()
        {
            Time.timeScale = 0;
        }

        [ContextMenu("Resume Game")]
        public void Resume()
        {
            Time.timeScale = 1;
        }

        [ContextMenu("Stop Game")]
        public void StopGame()
        {
            _enemySpawner.StopSpawner();
            _enemyManager.UnspawnAll();
            _bulletManager.RemoveAllBullets();
        }

        [ContextMenu("Start Game")]
        public void StartGame()
        {
            _enemySpawner.RunSpawner();
        }
    }
}