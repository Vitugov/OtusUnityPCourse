using UnityEngine;

namespace ShootEmUp
{
    public sealed class CountdownGameState : IGameState
    {
        private LevelResetter _levelResetter;

        public CountdownGameState(LevelResetter levelResetter)
        {
            _levelResetter = levelResetter;
        }
        public void Enter()
        {
            Time.timeScale = 0;
            _levelResetter.ResetLevel();
        }

        public void Exit()
        {
        }
    }
}
