namespace ShootEmUp
{
    public class PausedGameStateUIHandler : IGameStateUIHandler
    {
        public void EnterStateUI(UIManager uiManager)
        {
            uiManager.SetActiveResumeGameButton(true);
            uiManager.SetActiveStartGameButton(true);
            uiManager.SetActiveExitGameButton(true);
        }

        public void ExitStateUI(UIManager uiManager)
        {
            uiManager.SetActiveResumeGameButton(false);
            uiManager.SetActiveStartGameButton(false);
            uiManager.SetActiveExitGameButton(false);
        }
    }
}
