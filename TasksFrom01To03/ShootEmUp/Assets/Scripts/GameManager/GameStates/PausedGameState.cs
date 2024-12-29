using UnityEngine;

namespace ShootEmUp
{
    public sealed class PausedGameState : IGameState
    {
        public void Enter()
        {
            Time.timeScale = 0;
        }

        public void Exit()
        {
        }
    }
}
