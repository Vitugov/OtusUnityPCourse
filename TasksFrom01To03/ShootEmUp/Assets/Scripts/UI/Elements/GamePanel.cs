using UnityEngine;

namespace ShootEmUp
{
    public sealed class GamePanel : MonoBehaviour, IActivateableUI
    {
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
