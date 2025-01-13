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
            var moveCoroutineLogic = new ActionCoroutineLogic<MoveComponent>(moveComponent => moveComponent.MoveInDirectionToPoint(destination));
            _toDestinationMover = _coroutineManager.GetCoroutineHandler(moveCoroutineLogic, _moveComponent);

            var checkCoroutineLogick = new ConditionalCoroutineLogic<MoveComponent>(IsDesinationAchieved, CHECK_INTERVAL, DestinationIsReached, true);
            _destinationAchievedChecker = _coroutineManager.GetCoroutineHandler(checkCoroutineLogick, _moveComponent);

            bool IsDesinationAchieved(MoveComponent moveComponent) => (moveComponent.Position - destination).magnitude < TRESHHOLD;
        }

        public void StartMove()
        {
            _coroutineManager.StartCoroutine(_toDestinationMover);
            _coroutineManager.StartCoroutine(_destinationAchievedChecker);
        }

        public void StopMove()
        {
            if (_isActive)
            {
                _coroutineManager.StopCoroutineIfRunning(_toDestinationMover);
                _toDestinationMover = null;

                _coroutineManager.StopCoroutineIfRunning(_destinationAchievedChecker);
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