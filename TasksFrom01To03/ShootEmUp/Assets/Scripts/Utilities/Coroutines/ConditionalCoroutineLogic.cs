using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class ConditionalCoroutineLogic : ICoroutineLogic
    {
        private ICoroutineHandler _handler;
        private GameObject _target;
        private readonly Predicate<GameObject> _condition;
        private readonly float _checkInterval;
        private readonly Action _onConditionMet;
        private readonly bool _stopOnConditionMet;

        public ConditionalCoroutineLogic(Predicate<GameObject> condition, float checkInterval, Action onConditionMet, bool stopOnConditionMet)
        {
            _condition = condition;
            _checkInterval = checkInterval;
            _onConditionMet = onConditionMet;
            _stopOnConditionMet = stopOnConditionMet;
        }

        public void Initialize(ICoroutineHandler handler, GameObject target)
        {
            _handler = handler;
            _target = target;
        }

        public IEnumerator Execute()
        {
            while (true)
            {
                if (!_handler.IsPaused && _condition(_target))
                {
                    _onConditionMet.Invoke();
                    if (_stopOnConditionMet)
                    {
                        _handler.Stop();
                        yield break;
                    }
                }
                yield return new WaitForSeconds(_checkInterval);
            }
        }
    }
}
