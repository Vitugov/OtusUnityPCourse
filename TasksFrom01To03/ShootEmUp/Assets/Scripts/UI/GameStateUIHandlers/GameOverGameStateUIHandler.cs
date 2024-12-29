namespace ShootEmUp
{
    public sealed class GameOverGameStateUIHandler : IGameStateUIHandler<GameOverGameState>
    {
        public void EnterStateUI(UIManager uiManager)
        {
            uiManager.SetActiveGameOverPanel(true);
            uiManager.SetActiveStartGameButton(true);
            uiManager.SetActiveExitGameButton(true);
        }

        public void ExitStateUI(UIManager uiManager)
        {
            uiManager.SetActiveGameOverPanel(false);
            uiManager.SetActiveStartGameButton(false);
            uiManager.SetActiveExitGameButton(false);
        }
    }
}
