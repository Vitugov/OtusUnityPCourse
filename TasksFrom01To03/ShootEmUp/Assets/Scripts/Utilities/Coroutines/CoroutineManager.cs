using System.Collections.Generic;
using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CoroutineManager : MonoBehaviour
    {
        private MonoBehaviour _coroutineOwner;
        private HashSet<ICoroutineHandler> _coroutineHandlers;

        public IReadOnlyCollection<ICoroutineHandler> CoroutineHandlers => _coroutineHandlers;

        public void Awake()
        {
            _coroutineOwner = this;
            _coroutineHandlers = new();
        }

        public ICoroutineHandler GetCoroutineHandler<T>(ICoroutineLogic<T> coroutineLogic, T target)
            => new CoroutineHandler<T>(_coroutineOwner, coroutineLogic, target);

        public void StartCoroutine(ICoroutineHandler conditionHandler)
        {
            if (_coroutineHandlers.Contains(conditionHandler))
                throw new ArgumentException("You are trying to start coroutine twice");

            conditionHandler.CoroutineFinished += () => StopCoroutineIfRunning(conditionHandler);
            _coroutineHandlers.Add(conditionHandler);
            conditionHandler.Start();
        }

        public void StopCoroutineIfRunning(ICoroutineHandler conditionHandler)
        {
            if (!_coroutineHandlers.Contains(conditionHandler)) { return; }

            conditionHandler.CoroutineFinished -= () => StopCoroutineIfRunning(conditionHandler);
            _coroutineHandlers.Remove(conditionHandler);
            conditionHandler?.Stop();
        }
    }
}
