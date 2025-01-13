using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class OutOfBoundsNotifier : MonoBehaviour
    {
        public event Action OutOfBounds;

        private const float CHECK_INTERVAL = 0.05f;

        private LevelBounds _levelBounds;
        private CoroutineManager _coroutineManager;
        private ICoroutineHandler _coroutineHandler;

        public void Initialize(CoroutineManager coroutineManager)
        {
            _coroutineManager = coroutineManager;
            _coroutineHandler = GetCoroutineHandler(_coroutineManager);
        }

        public void StartNotifier(LevelBounds levelBounds)
        {
            _levelBounds = levelBounds;
            _coroutineManager.StartCoroutine(_coroutineHandler);
        }

        public void Stop()
        {
            _coroutineManager.StopCoroutineIfRunning(_coroutineHandler);
        }

        private ICoroutineHandler GetCoroutineHandler(CoroutineManager coroutineManager)
        {
            var coroutineLogic = new ConditionalCoroutineLogic<GameObject>(IsOutOfBounds, CHECK_INTERVAL, OnOutOfBounds, true);
            var coroutineHandler = coroutineManager.GetCoroutineHandler(coroutineLogic, gameObject);

            return coroutineHandler;

            bool IsOutOfBounds(GameObject gameObject) => !_levelBounds.InBounds(gameObject.transform.position);
        }

        private void OnOutOfBounds() => OutOfBounds?.Invoke();
    }
}
