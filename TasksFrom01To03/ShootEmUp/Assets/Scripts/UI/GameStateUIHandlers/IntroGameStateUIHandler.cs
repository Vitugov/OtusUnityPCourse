namespace ShootEmUp
{
    public sealed class IntroGameStateUIHandler : IGameStateUIHandler
    {
        public void EnterStateUI(UIManager uiManager) => ChangeActivity(uiManager, true);

        public void ExitStateUI(UIManager uiManager) => ChangeActivity(uiManager, false);

        private void ChangeActivity(UIManager uiManager, bool isActive)
        {
            uiManager.SetActiveStartGameButton(isActive);
            uiManager.SetActiveExitGameButton(isActive);
        }
    }
}
