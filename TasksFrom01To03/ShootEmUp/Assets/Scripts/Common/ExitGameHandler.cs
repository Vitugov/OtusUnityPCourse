using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ShootEmUp
{

    public sealed class ExitGameHandler : MonoBehaviour
    {
        public void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}
