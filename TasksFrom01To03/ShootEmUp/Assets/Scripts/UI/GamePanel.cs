using UnityEngine;

namespace ShootEmUp
{
    public class GamePanel : MonoBehaviour, IHideableUI
    {
        [SerializeField] private GameObject _gamePanel;
        public void Show()
        {
            _gamePanel.SetActive(true);
        }

        public void Hide()
        {
            _gamePanel.SetActive(false);
        }
    }
}
