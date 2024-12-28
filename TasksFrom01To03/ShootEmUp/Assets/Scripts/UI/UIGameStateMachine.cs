using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public sealed class UIGameStateMachine
    {
        private readonly Dictionary<Type, IGameStateUIHandler> _uiHandlers = new();
        private UIManager _uiManager;

        public void RegisterUIHandler<TGameState>(IGameStateUIHandler<TGameState> handler) where TGameState : IGameState
        {
            _uiHandlers.Add(typeof(TGameState), handler);
        }

        public void EnterState(Type stateType)
        {
            var handler = _uiHandlers[stateType];
            handler.EnterStateUI(_uiManager);
        }

        public void ExitState(Type stateType)
        {
            var handler = _uiHandlers[stateType];
            handler.ExitStateUI(_uiManager);
        }
    }
}
