using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour
    {
        [SerializeField] private CoroutineManager _coroutineManager;
        [SerializeField] private BackgroundParameters _parameters;

        private ICoroutineHandler _coroutineHandler;
        private MoveBackgroundComponent _moveBackgroundComponent;

        private void Start()
        {
            _moveBackgroundComponent = new MoveBackgroundComponent(_parameters, transform.position.x, transform.position.z);
            var logic = new ActionCoroutineLogic<Transform>(_moveBackgroundComponent.Move);
            _coroutineHandler = _coroutineManager.GetCoroutineHandler(logic, transform);
            _coroutineManager.StartCoroutine(_coroutineHandler);
        }
    }
}