using UnityEngine;

namespace ShootEmUp
{
    public sealed class Pauseables : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private BulletManager _bulletManager;
        [SerializeField] private CoroutinePauser _coroutinePauser;

        private IPauseable[] _pauseables;

        private void Awake()
        {
            _pauseables = new IPauseable[] { _inputManager, _bulletManager, _coroutinePauser };
        }

        public void Pause() => ChangeStateTo(true);

        public void Resume() => ChangeStateTo(false);

        private void ChangeStateTo(bool isPaused)
        {
            foreach (var pauseable in _pauseables)
            {
                pauseable.IsPaused = isPaused;
            }
        }
    }
}
