using UnityEngine;

namespace ShootEmUp
{
    public sealed class CountdownGameState : IGameState
    {
        private LevelResetter _levelResetter;
        private readonly Pauseables _pauseables;

        public CountdownGameState(LevelResetter levelResetter, Pauseables pauseables)
        {
            _levelResetter = levelResetter;
            _pauseables = pauseables;
        }

        public void Enter()
        {
            _pauseables.Pause();
            _levelResetter.ResetLevel();
        }
    }
}
