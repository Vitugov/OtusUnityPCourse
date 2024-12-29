using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public sealed class UIGameStateMachine
    {
        private readonly Dictionary<Type, IGameStateUIHandler> _uiHandlers;
        private UIManager _uiManager;

        public UIGameStateMachine(UIManager uIManager, Dictionary<Type, IGameStateUIHandler> uiHandlers)
        {
            _uiManager = uIManager;
            _uiHandlers = uiHandlers;
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
