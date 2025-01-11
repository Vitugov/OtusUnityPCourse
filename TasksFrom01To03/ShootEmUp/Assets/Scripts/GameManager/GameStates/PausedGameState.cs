namespace ShootEmUp
{
    public sealed class PausedGameState : IGameState
    {
        private readonly Pauseables _pauseables;

        public PausedGameState(Pauseables pauseables)
        {
            _pauseables = pauseables;
        }

        public void Enter()
        {
            _pauseables.Pause();
        }
    }
}
