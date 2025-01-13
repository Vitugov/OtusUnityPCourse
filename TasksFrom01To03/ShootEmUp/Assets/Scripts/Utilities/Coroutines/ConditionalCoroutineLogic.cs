using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class ConditionalCoroutineLogic<T> : ICoroutineLogic<T>
    {
        private ICoroutineHandler _handler;
        private T _target;
        private readonly Predicate<T> _condition;
        private readonly float _checkInterval;
        private readonly Action _onConditionMet;
        private readonly bool _stopOnConditionMet;

        public ConditionalCoroutineLogic(Predicate<T> condition, float checkInterval, Action onConditionMet, bool stopOnConditionMet)
        {
            _condition = condition;
            _checkInterval = checkInterval;
            _onConditionMet = onConditionMet;
            _stopOnConditionMet = stopOnConditionMet;
        }

        public void Initialize(ICoroutineHandler handler, T target)
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
