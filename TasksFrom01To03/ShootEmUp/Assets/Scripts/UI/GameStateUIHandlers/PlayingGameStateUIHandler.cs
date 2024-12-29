namespace ShootEmUp
{
    public sealed class PlayingGameStateUIHandler : IGameStateUIHandler<PlayingGameState>
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
