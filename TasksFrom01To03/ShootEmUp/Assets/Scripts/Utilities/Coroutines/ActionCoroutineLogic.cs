using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class ActionCoroutineLogic : ICoroutineLogic
    {
        private ICoroutineHandler _handler;
        private GameObject _target;
        private readonly Action<GameObject> _action;

        public ActionCoroutineLogic(Action<GameObject> action)
        {
            _action = action;
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
                if (!_handler.IsPaused)
                {
                    _action(_target);
                }
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
