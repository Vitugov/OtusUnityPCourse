namespace ShootEmUp
{
    public sealed class GameOverGameState : IGameState
    {
        private readonly Pauseables _pauseables;

        public GameOverGameState(Pauseables pauseables)
        {
            _pauseables = pauseables;
        }

        public void Enter()
        {
            _pauseables.Pause();
        }
    }
}
