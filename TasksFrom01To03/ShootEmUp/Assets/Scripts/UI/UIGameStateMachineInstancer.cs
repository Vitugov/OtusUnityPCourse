using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class UIGameStateMachineInstancer : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager;

        public UIGameStateMachine GetInstance()
        {
            var uiHandlers = new Dictionary<Type, IGameStateUIHandler>
            {
                [typeof(IntroGameState)] = new IntroGameStateUIHandler(),
                [typeof(CountdownGameState)] = new CountdownGameStateUIHandler(),
                [typeof(PlayingGameState)] = new PlayingGameStateUIHandler(),
                [typeof(PausedGameState)] = new PausedGameStateUIHandler(),
                [typeof(GameOverGameState)] = new GameOverGameStateUIHandler(),
                [typeof(ExitingGameState)] = new ExitingGameStateUIHandler()
            };

            return new(_uiManager, uiHandlers);
        }
    }
}
