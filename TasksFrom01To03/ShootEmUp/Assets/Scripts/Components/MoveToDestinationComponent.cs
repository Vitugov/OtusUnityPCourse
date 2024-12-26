using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class MoveToDestinationComponent : MonoBehaviour
    {
        public event Action DestinationIsReachedEvent;

        private const float CHECK_INTERVAL = 0.05f;
        private const double TRESHHOLD = 0.25;

        [SerializeField] private MoveComponent _moveComponent;

        private ConditionHandler _destinationAchievedChecker;

        public void SetDestination(Vector2 destiantion)
        {
            _moveComponent.MoveInDirectionToPoint(destiantion);
            _destinationAchievedChecker = new ConditionHandler(IsDesinationAchieved, CHECK_INTERVAL, DestinationIsReached, true);

            bool IsDesinationAchieved(GameObject obj) => ((Vector2)transform.position - destiantion).magnitude < TRESHHOLD;
        }

        public void StartMove()
        {
            _destinationAchievedChecker.Start(this, gameObject);
        }

        public void StopMove()
        {
            _moveComponent.MoveInDirection(Vector2.zero);
            _destinationAchievedChecker?.Stop(this);
            _destinationAchievedChecker = null;
        }

        private void DestinationIsReached()
        {
            StopMove();
            DestinationIsReachedEvent?.Invoke();
        }
    }
}