using UnityEngine;


namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private InitialGameTimer _timer;
        [SerializeField] private GameObject _gameOver;
        [SerializeField] private BulletManager _bulletManager;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private Character _character;

        public void FinishGame()
        {
            _gameOver.SetActive(true);
            Pause();
            //Debug.Log("Game over!");
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
            Pause();
        }

        [ContextMenu("Start Game")]
        public void StartGame()
        {
            _gameOver.SetActive(false);
            _bulletManager.RemoveAllBullets();
            _enemyManager.UnspawnAll();
            _character.LoadCharacterInitialState();
            _timer.TimerFinish += Resume;
            _timer.StartTimer();
        }
    }
}