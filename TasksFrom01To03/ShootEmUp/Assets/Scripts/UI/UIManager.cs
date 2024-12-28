using UnityEngine;

namespace ShootEmUp
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private InitialGameTimer _timer;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private StartGameButton _startGameButton;
        [SerializeField] private ExitGameButton _exitGameButton;
        [SerializeField] private PauseButton _pauseGameButton;
    }
}
