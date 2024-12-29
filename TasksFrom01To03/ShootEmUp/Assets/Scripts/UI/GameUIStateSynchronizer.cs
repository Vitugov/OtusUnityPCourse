namespace ShootEmUp
{
    public sealed class GameUIStateSynchronizer
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly UIGameStateMachine _uiStateMachine;

        public GameUIStateSynchronizer(GameStateMachine gameStateMachine, UIGameStateMachine uiStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _uiStateMachine = uiStateMachine;
            Start();
        }

        public void Start()
        {
            _gameStateMachine.OnEnterState += _uiStateMachine.EnterState;
            _gameStateMachine.OnExitState += _uiStateMachine.ExitState;
        }

        public void Stop()
        {
            _gameStateMachine.OnEnterState -= _uiStateMachine.EnterState;
            _gameStateMachine.OnExitState -= _uiStateMachine.ExitState;
        }
    }
}
