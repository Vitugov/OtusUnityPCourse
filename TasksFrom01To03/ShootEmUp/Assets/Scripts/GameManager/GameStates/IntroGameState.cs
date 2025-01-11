namespace ShootEmUp
{
    public sealed class IntroGameState : IGameState
    {
        private readonly Pauseables _pauseables;

        public IntroGameState(Pauseables pauseables)
        {
            _pauseables = pauseables;
        }

        public void Enter()
        {
            _pauseables.Pause();
        }
    }
}
