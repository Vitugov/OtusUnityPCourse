using System;
using UnityEngine;

namespace ShootEmUp
{
    public class UIManager : MonoBehaviour
    {
        public event Action StartGameButtonPressed;
        public event Action ExitGameButtonPressed;
        public event Action PauseGameButtonPressed;
        public event Action ResumeGameButtonPressed;
        public event Action IntroTimerFinished;

        [SerializeField] private IntroGameTimer _introTimer;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameButton _startGameButton;
        [SerializeField] private GameButton _exitGameButton;
        [SerializeField] private GameButton _pauseGameButton;
        [SerializeField] private GameButton _resumeGameButton;

        private void Awake()
        {
            _introTimer.OnTimerFinished += OnIntroTimerFinished;
            _startGameButton.OnClick += OnStartGameButtonPressed;
            _exitGameButton.OnClick += OnExitGameButtonPressed;
            _pauseGameButton.OnClick += OnPauseGameButtonPressed;
            _resumeGameButton.OnClick += OnResumeGameButtonPressed;
        }

        public void StartIntroTimer() => _introTimer.StartTimer();

        public void SetActiveGameOverPanel(bool isActive) => _gameOverPanel.SetActive(isActive);

        public void SetActiveStartGameButton(bool isActive) => _startGameButton.SetActive(isActive);

        public void SetActiveExitGameButton(bool isActive) => _exitGameButton.SetActive(isActive);

        public void SetActivePauseGameButton(bool isActive) => _pauseGameButton.SetActive(isActive);

        public void SetActiveResumeGameButton(bool isActive) => _resumeGameButton.SetActive(isActive);

        private void OnIntroTimerFinished() => IntroTimerFinished?.Invoke();

        private void OnStartGameButtonPressed() => StartGameButtonPressed?.Invoke();

        private void OnExitGameButtonPressed() => ExitGameButtonPressed?.Invoke();

        private void OnPauseGameButtonPressed() => PauseGameButtonPressed?.Invoke();

        private void OnResumeGameButtonPressed() => ResumeGameButtonPressed?.Invoke();
    }
}
