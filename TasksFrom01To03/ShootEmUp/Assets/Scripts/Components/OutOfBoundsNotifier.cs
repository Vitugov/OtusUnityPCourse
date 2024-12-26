using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class OutOfBoundsNotifier : MonoBehaviour
    {
        private const float CHECK_INTERVAL = 1f;
        private ConditionHandler _conditionHandler;

        public void InitializeAndStart(LevelBounds levelBounds, Action onOutOfBounds)
        {
            _conditionHandler = new ConditionHandler(condition, CHECK_INTERVAL, onOutOfBounds, true);
            _conditionHandler.Start(this, gameObject);

            bool condition(GameObject obj) => !levelBounds.InBounds(obj.transform.position);
        }

        public void Cleanup()
        {
            _conditionHandler?.Stop(this);
            _conditionHandler = null;
        }
    }
}

