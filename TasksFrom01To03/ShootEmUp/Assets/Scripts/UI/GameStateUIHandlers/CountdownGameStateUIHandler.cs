namespace ShootEmUp
{
    public sealed class CountdownGameStateUIHandler : IGameStateUIHandler<CountdownGameState>
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
