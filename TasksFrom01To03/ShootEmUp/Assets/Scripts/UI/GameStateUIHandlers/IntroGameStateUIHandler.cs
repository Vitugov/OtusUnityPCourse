namespace ShootEmUp
{
    public sealed class IntroGameStateUIHandler : IGameStateUIHandler<IntroGameState>
    {
        public void EnterStateUI(UIManager uiManager)
        {
            uiManager.SetActiveStartGameButton(true);
            uiManager.SetActiveExitGameButton(true);
        }

        public void ExitStateUI(UIManager uiManager)
        {
            uiManager.SetActiveStartGameButton(false);
            uiManager.SetActiveExitGameButton(false);
        }
    }
}
