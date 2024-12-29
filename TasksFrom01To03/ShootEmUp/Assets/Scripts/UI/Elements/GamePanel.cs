using UnityEngine;

namespace ShootEmUp
{
    public class GamePanel : MonoBehaviour, IActivateableUI
    {
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
