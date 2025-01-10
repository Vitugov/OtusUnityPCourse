using ShootEmUp;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public sealed class CoroutineManager
    {
        private MonoBehaviour _coroutineOwner;
        private readonly HashSet<ICoroutineHandler> _coroutineHandlers;

        public IReadOnlyCollection<ICoroutineHandler> CoroutineHandlers => _coroutineHandlers;

        public CoroutineManager(MonoBehaviour corutineOwner)
        {
            _coroutineOwner = corutineOwner;
            _coroutineHandlers = new();
        }

        public ICoroutineHandler GetCoroutineHandler(ICoroutineLogic coroutineLogic)
        {
            var conditionHandler = new CoroutineHandler(_coroutineOwner, coroutineLogic);
            conditionHandler.CoroutineFinished += () => StopCoroutine(conditionHandler);
            _coroutineHandlers.Add(conditionHandler);
            return conditionHandler;
        }

        public void StartCoroutine(ICoroutineHandler conditionHandler, GameObject target)
        {
            conditionHandler.Start(target);
        }

        public void StopCoroutine(ICoroutineHandler conditionHandler)
        {
            conditionHandler.CoroutineFinished -= () => StopCoroutine(conditionHandler);
            conditionHandler.Stop();
            _coroutineHandlers.Remove(conditionHandler);
        }
    }
}
