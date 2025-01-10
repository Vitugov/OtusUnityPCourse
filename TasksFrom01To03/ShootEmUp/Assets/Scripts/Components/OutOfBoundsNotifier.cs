using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class OutOfBoundsNotifier : MonoBehaviour
    {
        private const float CHECK_INTERVAL = 1f;
        private ConditionalCoroutineHandler _conditionHandler;

        public void InitializeAndStart(LevelBounds levelBounds, Action onOutOfBounds)
        {
            _conditionHandler = new ConditionalCoroutineHandler(this, condition, CHECK_INTERVAL, onOutOfBounds, true);
            _conditionHandler.Start(gameObject);

            bool condition(GameObject obj) => !levelBounds.InBounds(obj.transform.position);
        }

        public void Cleanup()
        {
            _conditionHandler?.Stop();
            _conditionHandler = null;
        }
    }
}

