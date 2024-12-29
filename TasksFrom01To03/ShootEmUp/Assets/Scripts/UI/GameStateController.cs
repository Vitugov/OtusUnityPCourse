using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public sealed class GameStateController
    {
        private GameStateMachine _gameStateMachine;
        private UIGameStateMachine _uiStateMachine;
        private UIManager _uiManager;
        private ExitGameHandler _exitGameHandler;
        private CharacterController _characterController;
        private LevelResetter _levelResetter;


        public GameStateController(UIManager uiManager, CharacterController characterController, ExitGameHandler exitGameHandler, LevelResetter levelResetter)
        {
            _uiManager = uiManager;
            _exitGameHandler = exitGameHandler;
            _characterController = characterController;
            _levelResetter = levelResetter;

            var states = new Dictionary<Type, IGameState>
            {
                [typeof(IntroGameState)] = new IntroGameState(),
                [typeof(CountdownGameState)] = new CountdownGameState(_levelResetter),
                [typeof(PlayingGameState)] = new PlayingGameState(),
                [typeof(PausedGameState)] = new PausedGameState(),
                [typeof(GameOverGameState)] = new GameOverGameState()
            };

            _gameStateMachine = new GameStateMachine(states);
            _uiStateMachine = new UIGameStateMachine(_uiManager);

            _uiStateMachine.RegisterUIHandler(new IntroGameStateUIHandler());
            _uiStateMachine.RegisterUIHandler(new CountdownGameStateUIHandler());
            _uiStateMachine.RegisterUIHandler(new PlayingGameStateUIHandler());
            _uiStateMachine.RegisterUIHandler(new PausedGameStateUIHandler());
            _uiStateMachine.RegisterUIHandler(new GameOverGameStateUIHandler());

            _gameStateMachine.OnEnterState += stateType => _uiStateMachine.EnterState(stateType);
            _gameStateMachine.OnExitState += stateType => _uiStateMachine.ExitState(stateType);

            _uiManager.StartGameButtonPressed += OnStartGameButtonPressed;
            _uiManager.IntroTimerFinished += OnIntroTimerFinished;
            _uiManager.ExitGameButtonPressed += OnExitGameButtonPressed;
            _uiManager.PauseGameButtonPressed += OnPauseGameButtonPressed;
            _uiManager.ResumeGameButtonPressed += OnResumeGameButtonPressed;

            _characterController.CharacterDeath += OnCharacterDeath;

            _gameStateMachine.Enter<IntroGameState>();
        }


        private void OnStartGameButtonPressed() => _gameStateMachine.Enter<CountdownGameState>();

        private void OnExitGameButtonPressed() => _exitGameHandler.ExitGame();

        private void OnPauseGameButtonPressed() => _gameStateMachine.Enter<PausedGameState>();

        private void OnResumeGameButtonPressed() => _gameStateMachine.Enter<PlayingGameState>();

        private void OnIntroTimerFinished() => _gameStateMachine.Enter<PlayingGameState>();

        private void OnCharacterDeath() => _gameStateMachine.Enter<GameOverGameState>();
    }
}
