using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public sealed class GameButton : MonoBehaviour, IGameButton, IActivateableUI
    {
        public event Action OnClick;

        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonPressed);
        }

        public void OnButtonPressed()
        {
            OnClick?.Invoke();
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
