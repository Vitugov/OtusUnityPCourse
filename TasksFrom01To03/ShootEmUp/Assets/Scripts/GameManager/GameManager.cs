using UnityEngine;


namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private InitialGameTimer _timer;
        [SerializeField] private GameObject _gameOver;
        [SerializeField] private StartGameButton _startGameButton;

        [SerializeField] private BulletManager _bulletManager;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private Character _character;


        private void Awake()
        {
            _startGameButton.Initialize(StartGame);
        }

        [ContextMenu("Finish Game")]
        public void FinishGame()
        {
            _gameOver.SetActive(true);
            _startGameButton.Show();
            Pause();
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

        [ContextMenu("PreStartGame")]
        public void PreStartGame()
        {
            Pause();
            _startGameButton.Show();
            _gameOver.SetActive(false);
        }

        [ContextMenu("Start Game")]
        public void StartGame()
        {
            _gameOver.SetActive(false);
            _bulletManager.RemoveAllBullets();
            _enemyManager.UnspawnAll();
            _character.LoadCharacterInitialState();
            _timer.StartTimer(OnGameStart);
        }

        private void OnGameStart()
        {
            Resume();
        }
    }
}