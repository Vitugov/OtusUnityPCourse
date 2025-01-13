using System;
using UnityEngine;

namespace ShootEmUp
{
    public class CoroutineHandler<T> : ICoroutineHandler
    {
        public event Action CoroutineFinished;

        private readonly MonoBehaviour _owner;
        private readonly ICoroutineLogic<T> _logic;
        private readonly T _target;

        private Coroutine _coroutine;

        public bool IsFinished { get; private set; }

        public bool IsPaused { get; set; }

        public CoroutineHandler(MonoBehaviour owner, ICoroutineLogic<T> logic, T target)
        {
            _owner = owner;
            _logic = logic;
            _target = target;
            _logic.Initialize(this, _target);
        }

        public void Start()
        {
            IsFinished = false;
            _coroutine = _owner.StartCoroutine(_logic.Execute());
        }

        public void Stop()
        {
            if (IsFinished) { return; }

            IsFinished = true;
            IsPaused = false;
            _owner.StopCoroutine(_coroutine);
            _coroutine = null;
            CoroutineFinished?.Invoke();
        }
    }
}

