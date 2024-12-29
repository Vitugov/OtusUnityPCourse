using UnityEngine;

namespace ShootEmUp
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Character _character;
        [SerializeField] private CharacterInitializer _characterInitializer;
        [SerializeField] private ExitGameHandler _exitGameHandler;
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private LevelResetter _levelResetter;

        private GameStateController _gameStateController;

        private void Awake()
        {
            _characterInitializer.Initialize(_character);
            _gameStateController = new GameStateController(_uiManager, _characterController, _exitGameHandler, _levelResetter);
        }
    }
}
