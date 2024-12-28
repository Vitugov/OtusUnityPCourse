using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public class GameStateMachine
    {
        public IGameState CurrentGameState { get; private set; }

        private Dictionary<Type, IGameState> _gameStates;

        public GameStateMachine()
        {
            _gameStates = new Dictionary<Type, IGameState>
            {
                [typeof(IntroGameState)] = new IntroGameState(),
                [typeof(CountdownGameState)] = new CountdownGameState(),
                [typeof(PlayingGameState)] = new PlayingGameState(),
                [typeof(PausedGameState)] = new PausedGameState(),
                [typeof(GameOverGameState)] = new GameOverGameState(),
            };
        }

        public void Enter<TState>() where TState : IGameState
        {
            CurrentGameState?.Exit();
            CurrentGameState = _gameStates[typeof(TState)];
            CurrentGameState.Enter();
        }
    }
}
