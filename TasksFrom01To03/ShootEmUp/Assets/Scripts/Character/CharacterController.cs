using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        public event Action CharacterDeath;

        [SerializeField] private Character _character;
        [SerializeField] private CharacterInitializer _characterInitializer;
        [SerializeField] private InputManager _inputManager;

        private void Awake()
        {
            _characterInitializer.Initialize(_character);
            
            _inputManager.DirectionKeyPressed += OnMove;
            _inputManager.SpacePressed += OnFire;
            _character.OnDeath += OnCharacterDeath;
        }

        private void OnDestroy()
        {
            if (_character != null)
            {
                _character.Deinitialize();
            }
            
            _inputManager.DirectionKeyPressed -= OnMove;
            _inputManager.SpacePressed -= OnFire;
            _character.OnDeath -= OnCharacterDeath;
        }

        private void OnMove(Vector2 direction) => _character.Move(direction);

        private void OnFire() => _character.Fire();

        private void OnCharacterDeath() => CharacterDeath?.Invoke();
    }
}