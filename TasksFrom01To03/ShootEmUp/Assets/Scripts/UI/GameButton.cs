using System;
using UnityEngine;

namespace ShootEmUp
{
    public class GameButton : MonoBehaviour, IGameButton, IHideableUI
    {
        public event Action OnClick;

        [SerializeField] private GameObject _gameButton;

        public void OnButtonPressed()
        {
            OnClick?.Invoke();
        }

        public void Show()
        {
            _gameButton.SetActive(true);
        }

        public void Hide()
        {
            _gameButton.SetActive(false);
        }
    }
}
