using System;
using UnityEngine;

namespace ShootEmUp
{
    public class CoroutineHandler : ICoroutineHandler
    {
        public event Action CoroutineFinished;

        private readonly MonoBehaviour _owner;
        private readonly ICoroutineLogic _logic;

        private Coroutine _coroutine;
        
        public bool IsFinished { get; private set; }

        public bool IsPaused { get; private set; }

        public CoroutineHandler(MonoBehaviour owner, ICoroutineLogic logic)
        {
            _owner = owner;
            _logic = logic;
        }

        public void Start(GameObject target)
        {
            _logic.Initialize(this, target);
            _coroutine = _owner.StartCoroutine(_logic.Execute());
        }

        public void Stop()
        {
            if (!IsFinished)
            {
                _owner.StopCoroutine(_coroutine);
                CoroutineFinished?.Invoke();
                _coroutine = null;
                IsFinished = true;
            }
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }
    }
}

