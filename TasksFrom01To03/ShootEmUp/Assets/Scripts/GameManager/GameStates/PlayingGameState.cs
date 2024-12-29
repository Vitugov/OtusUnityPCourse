using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayingGameState : IGameState
    {
        public void Enter()
        {
            Time.timeScale = 1;
        }

        public void Exit()
        {
        }
    }
}
