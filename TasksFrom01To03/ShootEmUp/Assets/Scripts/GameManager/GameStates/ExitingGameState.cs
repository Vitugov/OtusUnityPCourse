namespace ShootEmUp
{
    public class ExitingGameState : IGameState
    {
        private ExitGameHandler _exitGameHandler;

        public ExitingGameState(ExitGameHandler exitGameHandler)
        {
            _exitGameHandler = exitGameHandler;
        }

        public void Enter()
        {
            _exitGameHandler.ExitGame();
        }
    }
}
