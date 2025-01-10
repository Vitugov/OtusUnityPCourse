using System;
using System.Collections;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class ActionCoroutineHandler : ICoroutineHandler
    {
        public event Action CoroutineFinished;

        private readonly MonoBehaviour _owner;
        private readonly Action<GameObject> _action;

        private Coroutine _coroutine;
        private bool _isFinished;
        public bool IsFinished
        {
            get => _isFinished;
            private set => ApplyIsFinishState(value);
        }

        public bool IsPaused { get; private set; }

        public ActionCoroutineHandler(MonoBehaviour owner, Action<GameObject> action)
        {
            _owner = owner;
            _action = action;
        }

        public void Start(GameObject target)
        {
            _coroutine = _owner.StartCoroutine(ActionCoroutine(_action, target));
        }

        public void Stop()
        {
            IsFinished = true;
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        private void ApplyIsFinishState(bool value)
        {
            if (value && !_isFinished)
            {
                _owner.StopCoroutine(_coroutine);
                CoroutineFinished?.Invoke();
                _coroutine = null;
                _isFinished = true;
            }
        }

        private IEnumerator ActionCoroutine(Action<GameObject> action, GameObject target)
        {
            while (true)
            {
                if (!IsPaused)
                {
                    action(target);
                }

                yield return new WaitForFixedUpdate();
            }
        }
    }
}
