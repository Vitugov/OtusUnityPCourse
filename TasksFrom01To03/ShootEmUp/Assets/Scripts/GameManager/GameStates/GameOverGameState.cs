using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameOverGameState : IGameState
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
