using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayingGameState : IGameState
    {
        private readonly Pauseables _pauseables;

        public PlayingGameState(Pauseables pauseables)
        {
            _pauseables = pauseables;
        }

        public void Enter()
        {
            _pauseables.Resume();
        }
    }
}
