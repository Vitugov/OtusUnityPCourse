using UnityEngine;


namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private CharacterInitializer _characterInitializer;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private GameManager _gameManager;

        private void Awake()
        {
            _characterInitializer.Initialize(_character);
        }

        private void OnEnable()
        {
            _inputManager.DirectionKeyPressed += OnMove;
            _inputManager.SpacePressed += OnFire;
            _character.OnDeath += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _inputManager.DirectionKeyPressed -= OnMove;
            _inputManager.SpacePressed -= OnFire;
            _character.OnDeath -= OnCharacterDeath;
        }

        private void OnDestroy()
        {
            if (_character != null)
            {
                _character.Deinitialize();
            }
        }

        private void OnMove(Vector2 direction)
        {
            _character.Move(direction, Time.fixedDeltaTime);
        }

        private void OnFire()
        {
            _character.Fire();
        }

        private void OnCharacterDeath()
        {
            _gameManager.FinishGame();
        }
    }
}