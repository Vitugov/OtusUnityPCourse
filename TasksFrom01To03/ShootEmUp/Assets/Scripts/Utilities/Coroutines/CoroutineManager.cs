using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CoroutineManager : MonoBehaviour
    {
        private MonoBehaviour _coroutineOwner;
        private readonly HashSet<ICoroutineHandler> _coroutineHandlers;

        public IReadOnlyCollection<ICoroutineHandler> CoroutineHandlers => _coroutineHandlers;

        public CoroutineManager()
        {
            _coroutineOwner = this;
            _coroutineHandlers = new();
        }

        public ICoroutineHandler GetCoroutineHandler(ICoroutineLogic coroutineLogic)
        {
            var conditionHandler = new CoroutineHandler(_coroutineOwner, coroutineLogic);
            conditionHandler.CoroutineFinished += () => ExcludeCoroutine(conditionHandler);
            _coroutineHandlers.Add(conditionHandler);
            return conditionHandler;
        }

        public void StartCoroutine(ICoroutineHandler conditionHandler, GameObject target)
        {
            conditionHandler.Start(target);
        }

        public void StopCoroutine(ICoroutineHandler conditionHandler)
        {
            ExcludeCoroutine(conditionHandler);
            conditionHandler?.Stop();
        }

        private void ExcludeCoroutine(ICoroutineHandler conditionHandler)
        {
            conditionHandler.CoroutineFinished -= () => ExcludeCoroutine(conditionHandler);
            _coroutineHandlers.Remove(conditionHandler);
        }
    }
}
