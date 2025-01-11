using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveToDestinationComponent : MonoBehaviour
    {
        public event Action DestinationReached;

        private const float CHECK_INTERVAL = 0.05f;
        private const double TRESHHOLD = 0.25;

        [SerializeField] private MoveComponent _moveComponent;

        private CoroutineManager _coroutineManager;
        private ICoroutineHandler _destinationAchievedChecker;
        private ICoroutineHandler _toDestinationMover;

        private bool _isActive;

        public void Initialize(CoroutineManager coroutineManager, Vector2 destination)
        {
            _isActive = true;
            _coroutineManager = coroutineManager;
            var moveCoroutineLogic = new ActionCoroutineLogic(gameObject => _moveComponent.MoveInDirectionToPoint(destination));
            _toDestinationMover = _coroutineManager.GetCoroutineHandler(moveCoroutineLogic);

            var checkCoroutineLogick = new ConditionalCoroutineLogic(IsDesinationAchieved, CHECK_INTERVAL, DestinationIsReached, true);
            _destinationAchievedChecker = _coroutineManager.GetCoroutineHandler(checkCoroutineLogick);

            bool IsDesinationAchieved(GameObject obj) => ((Vector2)transform.position - destination).magnitude < TRESHHOLD;
        }

        public void StartMove()
        {
            _coroutineManager.StartCoroutine(_toDestinationMover, gameObject);
            _coroutineManager.StartCoroutine(_destinationAchievedChecker, gameObject);
        }

        public void StopMove()
        {
            if (_isActive)
            {
                _coroutineManager.StopCoroutine(_toDestinationMover);
                _toDestinationMover = null;

                _coroutineManager.StopCoroutine(_destinationAchievedChecker);
                _destinationAchievedChecker = null;
                _isActive = false;
            }
        }

        private void DestinationIsReached()
        {
            StopMove();
            DestinationReached?.Invoke();
        }
    }
}