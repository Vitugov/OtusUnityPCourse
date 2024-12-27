using System;
using UnityEngine;

namespace ShootEmUp
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Character _character;
        [SerializeField] private CharacterInitializer _characterInitializer;
        [SerializeField] private GameManager _gameManager;

        private void Awake()
        {
            _characterInitializer.Initialize(_character);
            _characterController.CharacterDeath += _gameManager.FinishGame;
        }
    }
}
