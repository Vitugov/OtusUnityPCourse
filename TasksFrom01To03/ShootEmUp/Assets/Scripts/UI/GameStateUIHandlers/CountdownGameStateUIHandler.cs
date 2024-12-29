﻿namespace ShootEmUp
{
    public sealed class CountdownGameStateUIHandler : IGameStateUIHandler
    {
        public void EnterStateUI(UIManager uiManager)
        {
            uiManager.StartIntroTimer();
        }

        public void ExitStateUI(UIManager uiManager)
        {

        }
    }
}
