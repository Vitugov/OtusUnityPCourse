using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveToDestinationComponent2 : MonoBehaviour
    {
        [SerializeField] private NewMoveComponent _moveComponent;

        private Vector2 _destination;

        public void Initialize(Vector2 destination)
        {
            _destination = destination;
        }

        public void Tick()
        {
            _moveComponent.MoveInDirectionToPoint(_destination);
        }
    }
}
