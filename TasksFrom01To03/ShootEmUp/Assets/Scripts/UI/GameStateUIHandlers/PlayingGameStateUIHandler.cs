namespace ShootEmUp
{
    public sealed class PlayingGameStateUIHandler : IGameStateUIHandler
    {
        public void EnterStateUI(UIManager uiManager)
        {
            uiManager.SetActivePauseGameButton(true);
        }

        public void ExitStateUI(UIManager uiManager)
        {
            uiManager.SetActivePauseGameButton(false);
        }
    }
}
