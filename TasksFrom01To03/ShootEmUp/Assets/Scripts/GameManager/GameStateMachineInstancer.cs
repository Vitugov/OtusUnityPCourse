using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameStateMachineInstancer : MonoBehaviour
    {
        [SerializeField] private ExitGameHandler _exitGameHandler;
        [SerializeField] private LevelResetter _levelResetter;
        [SerializeField] private Pauseables _pauseables;

        public GameStateMachine GetInstance()
        {
            var states = new Dictionary<Type, IGameState>
            {
                [typeof(IntroGameState)] = new IntroGameState(_pauseables),
                [typeof(CountdownGameState)] = new CountdownGameState(_levelResetter, _pauseables),
                [typeof(PlayingGameState)] = new PlayingGameState(_pauseables),
                [typeof(PausedGameState)] = new PausedGameState(_pauseables),
                [typeof(GameOverGameState)] = new GameOverGameState(_pauseables),
                [typeof(ExitingGameState)] = new ExitingGameState(_exitGameHandler)
            };

            return new(states);
        }
    }
}
