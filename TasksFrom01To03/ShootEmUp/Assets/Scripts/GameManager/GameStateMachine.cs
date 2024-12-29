using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public class GameStateMachine
    {
        public event Action<Type> OnExitState;
        public event Action<Type> OnEnterState;

        private Dictionary<Type, IGameState> _gameStates;
        private IGameState _currentGameState;

        public IGameState CurrentGameState
        {
            get => _currentGameState;
            private set
            {
                if (_currentGameState == value) return;
                if (_currentGameState != null)
                {
                    OnExitState?.Invoke(_currentGameState.GetType());
                }
                _currentGameState = value;
                OnEnterState?.Invoke(_currentGameState.GetType());
            }
        }

        public GameStateMachine(Dictionary<Type, IGameState> gameStates)
        {
            _gameStates = gameStates;
        }

        public void Enter<TState>() where TState : IGameState
        {
            CurrentGameState = _gameStates[typeof(TState)];
            CurrentGameState.Enter();
        }
    }
}
