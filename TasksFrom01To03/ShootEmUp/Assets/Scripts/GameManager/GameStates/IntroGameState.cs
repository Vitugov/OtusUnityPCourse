using UnityEngine;

namespace ShootEmUp
{
    public sealed class IntroGameState : IGameState
    {
        public void Enter()
        {
            Time.timeScale = 0;
        }
    }
}
