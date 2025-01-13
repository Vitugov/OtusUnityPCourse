using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class ActionCoroutineLogic<T> : ICoroutineLogic<T>
    {
        private ICoroutineHandler _handler;
        private T _target;
        private readonly Action<T> _action;

        public ActionCoroutineLogic(Action<T> action)
        {
            _action = action;
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
                if (!_handler.IsPaused)
                {
                    _action(_target);
                }
                yield return new WaitForFixedUpdate();
            }
        }

    }
}
