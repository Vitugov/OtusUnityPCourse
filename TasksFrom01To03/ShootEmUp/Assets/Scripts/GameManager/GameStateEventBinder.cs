namespace ShootEmUp
{
    public sealed class GameStateEventBinder
    {
        public GameStateEventBinder(GameStateMachine gameStateMachine, UIManager uiManager, CharacterController characterController)
        {
            uiManager.IntroTimerFinished += gameStateMachine.Enter<PlayingGameState>;
            uiManager.ExitGameButtonPressed += gameStateMachine.Enter<ExitingGameState>;
            uiManager.StartGameButtonPressed += gameStateMachine.Enter<CountdownGameState>;
            uiManager.PauseGameButtonPressed += gameStateMachine.Enter<PausedGameState>;
            uiManager.ResumeGameButtonPressed += gameStateMachine.Enter<PlayingGameState>;

            characterController.CharacterDeath += gameStateMachine.Enter<GameOverGameState>;
        }
    }
}
