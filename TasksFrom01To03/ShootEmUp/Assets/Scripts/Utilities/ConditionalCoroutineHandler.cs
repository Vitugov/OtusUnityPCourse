using System;
using System.Collections;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class ConditionalCoroutineHandler
    {
        public event Action CoroutineFinished;

        private readonly MonoBehaviour _owner;
        private readonly Predicate<GameObject> _condition;
        private readonly float _checkInterval;
        private readonly Action _onConditionMet;
        private readonly bool _stopHandlerOnFirstConditionMeet;

        private Coroutine _coroutine;
        private bool _isFinished;
        public bool IsFinished
        {
            get => _isFinished;
            private set => ApplyIsFinishState(value);
        }
        public bool IsPaused { get; private set; }

        public ConditionalCoroutineHandler(MonoBehaviour owner, Predicate<GameObject> condition, float checkInterval, Action onConditionMet, bool stopHandlerOnFirstConditionMeet)
        {
            _owner = owner;
            _condition = condition;
            _checkInterval = checkInterval;
            _onConditionMet = onConditionMet;
            _stopHandlerOnFirstConditionMeet = stopHandlerOnFirstConditionMeet;
        }

        public void Start(GameObject target)
        {
            _coroutine = _owner.StartCoroutine(CheckCondition(target));
        }

        public void Stop()
        {
            IsFinished = true;
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        private void ApplyIsFinishState(bool value)
        {
            if (value && !_isFinished)
            {
                if (_coroutine != null)
                {
                    _owner.StopCoroutine(_coroutine);
                }
                CoroutineFinished?.Invoke();
                _coroutine = null;
                _isFinished = true;
            }
        }

        private IEnumerator CheckCondition(GameObject target)
        {
            while (true)
            {
                if (!IsPaused && _condition(target))
                {
                    _onConditionMet.Invoke();
                    if (_stopHandlerOnFirstConditionMeet)
                    {
                        IsFinished = true;
                        yield break;
                    }
                }

                yield return new WaitForSeconds(_checkInterval);
            }
        }
    }
}
