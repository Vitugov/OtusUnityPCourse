using System;
using UnityEngine;

namespace ShootEmUp
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] private GameObject _startGameButton;
        private Action _onButtonPressed;

        public void Initialize(Action onButtonPressed)
        {
            _onButtonPressed = onButtonPressed;
        }

        public void OnButtonPressed()
        {
            _onButtonPressed();
        }

        public void Show()
        {
            _startGameButton.SetActive(true);
        }

        public void Hide()
        {
            _startGameButton.SetActive(false);
        }
    }
}
