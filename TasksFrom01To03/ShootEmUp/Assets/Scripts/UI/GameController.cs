using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public class GameController
    {
        private GameStateMachine _gameStateMachine;
        private UIGameStateMachine _uiStateMachine;

        private void Start()
        {
            var states = new Dictionary<Type, IGameState>
            {
                [typeof(IntroGameState)] = new IntroGameState(),
                [typeof(CountdownGameState)] = new CountdownGameState(),
                [typeof(PlayingGameState)] = new PlayingGameState(),
                [typeof(PausedGameState)] = new PausedGameState(),
                [typeof(GameOverGameState)] = new GameOverGameState()
            };

            _gameStateMachine = new GameStateMachine(states);

            // Регистрация UI-хэндлеров
            _uiStateMachine.RegisterUIHandler(new IntroGameStateUIHandler());
            _uiStateMachine.RegisterUIHandler(new GameOverGameStateUIHandler());

            // Настройка связей
            _gameStateMachine.OnEnterState += stateType => _uiStateMachine.EnterState(stateType);
            _gameStateMachine.OnExitState += stateType => _uiStateMachine.ExitState(stateType);
        }

        private void OnStartGameButtonPressed()
        {
            _gameStateMachine.Enter<CountdownGameState>();
        }

        private void OnExitGameButtonPressed()
        {
            _gameStateMachine.Enter<GameOverGameState>();
        }

        private void OnPauseGameButtonPressed()
        {
            _gameStateMachine.Enter<PausedGameState>();
        }

        private void OnIntroTimerFinished()
        {
            _gameStateMachine.Enter<CountdownGameState>();
        }

        private void HandleEnterGameState(Type stateType)
        {
            _uiStateMachine.EnterState(stateType);
        }

        private void HandleExitGameState(Type stateType)
        {
            _uiStateMachine.ExitState(stateType);
        }
    }
}
