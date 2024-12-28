namespace ShootEmUp
{
    public interface IGameStateUIHandler<out TGameState> : IGameStateUIHandler
        where TGameState : IGameState
    {
    }

    public interface IGameStateUIHandler
    {
        void EnterStateUI(UIManager uiManager);
        void ExitStateUI(UIManager uiManager);
    }
}
