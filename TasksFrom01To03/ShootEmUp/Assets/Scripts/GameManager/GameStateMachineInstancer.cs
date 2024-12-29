using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameStateMachineInstancer : MonoBehaviour
    {
        [SerializeField] private ExitGameHandler _exitGameHandler;
        [SerializeField] private LevelResetter _levelResetter;

        public GameStateMachine GetInstance()
        {
            var states = new Dictionary<Type, IGameState>
            {
                [typeof(IntroGameState)] = new IntroGameState(),
                [typeof(CountdownGameState)] = new CountdownGameState(_levelResetter),
                [typeof(PlayingGameState)] = new PlayingGameState(),
                [typeof(PausedGameState)] = new PausedGameState(),
                [typeof(GameOverGameState)] = new GameOverGameState(),
                [typeof(ExitingGameState)] = new ExitingGameState(_exitGameHandler)
            };

            return new(states);
        }
    }
}
