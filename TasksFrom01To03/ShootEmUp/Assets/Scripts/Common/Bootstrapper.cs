using UnityEditorInternal;
using UnityEngine;

namespace ShootEmUp
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Character _character;
        [SerializeField] private CharacterInitializer _characterInitializer;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private GameStateMachineInstancer _gameStateMachineInstancer;
        [SerializeField] private UIGameStateMachineInstancer _uiGameStateMachineInstancer;

        private GameStateMachine _gameStateMachine;
        private UIGameStateMachine _uiGameStateMachine;
        private GameUIStateSynchronizer _gameUIStateSynchronizer;
        private GameStateEventBinder _gameStateEventBinder;

        private void Awake()
        {
            _characterInitializer.Initialize(_character);
            _gameStateMachine = _gameStateMachineInstancer.GetInstance();
            _uiGameStateMachine = _uiGameStateMachineInstancer.GetInstance();
            _gameUIStateSynchronizer = new GameUIStateSynchronizer(_gameStateMachine, _uiGameStateMachine);
            _gameStateEventBinder = new GameStateEventBinder(_gameStateMachine, _uiManager, _characterController);
            _gameStateMachine.Enter<IntroGameState>();
        }
    }
}
