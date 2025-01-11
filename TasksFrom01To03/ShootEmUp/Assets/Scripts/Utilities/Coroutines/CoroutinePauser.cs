using UnityEngine;

namespace ShootEmUp
{
    public sealed class CoroutinePauser : MonoBehaviour, IPauseable
    {
        [SerializeField] private CoroutineManager _coroutineManager;

        private bool _isPaused;
        public bool IsPaused
        {
            get => _isPaused;
            set
            {
                if (_isPaused == value) return;

                foreach (var handler in _coroutineManager.CoroutineHandlers)
                {
                    handler.IsPaused = value;
                }

                _isPaused = value;
            }
        }
    }
}
