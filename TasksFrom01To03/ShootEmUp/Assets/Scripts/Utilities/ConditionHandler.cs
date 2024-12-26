using System;
using System.Collections;
using UnityEngine;


namespace ShootEmUp
{
    public class ConditionHandler
    {
        private readonly Predicate<GameObject> _condition;
        private readonly float _checkInterval;
        private readonly Action _onConditionMet;
        private readonly bool _stopHandlerOnFirstConditionMeet;

        private Coroutine _coroutine;
        public bool IsRunning { get; private set; }

        public ConditionHandler(Predicate<GameObject> condition, float checkInterval, Action onConditionMet, bool stopHandlerOnFirstConditionMeet)
        {
            _condition = condition;
            _checkInterval = checkInterval;
            _onConditionMet = onConditionMet;
            _stopHandlerOnFirstConditionMeet = stopHandlerOnFirstConditionMeet;
        }

        public void Start(MonoBehaviour owner, GameObject target)
        {
            if (IsRunning) return;

            IsRunning = true;
            _coroutine = owner.StartCoroutine(CheckCondition(target));
        }

        public void Stop(MonoBehaviour owner)
        {
            if (!IsRunning) return;

            IsRunning = false;
            if (_coroutine != null)
            {
                owner.StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator CheckCondition(GameObject target)
        {
            while (true)
            {
                if (_condition(target))
                {
                    _onConditionMet.Invoke();
                    if (_stopHandlerOnFirstConditionMeet)
                    {
                        IsRunning = false;
                        yield break;
                    }
                }

                yield return new WaitForSeconds(_checkInterval);
            }
        }
    }
}
