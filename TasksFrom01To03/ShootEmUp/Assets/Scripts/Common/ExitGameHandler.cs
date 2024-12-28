using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ShootEmUp
{

    public class ExitGameHandler : MonoBehaviour
    {
        public void ExitGame()
        {
            Debug.Log("Exiting game...");

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}
