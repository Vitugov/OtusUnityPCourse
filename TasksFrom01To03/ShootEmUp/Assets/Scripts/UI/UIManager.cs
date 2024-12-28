using System;
using UnityEngine;

namespace ShootEmUp
{
    public class UIManager : MonoBehaviour
    {
        public event Action StartGameButtonPressed;
        public event Action ExitGameButtonPressed;
        public event Action PauseGameButtonPressed;
        public event Action IntroTimerFinished;

        public InitialGameTimer _timer;
        public GameObject _gameOverPanel;
        public GameButton _startGameButton;
        public GameButton _exitGameButton;
        public GameButton _pauseGameButton;
        public GameButton _resumeGameButton;



    }
}
