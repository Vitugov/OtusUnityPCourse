using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveWithRestrictions : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        private IRestrictor _restrictor;

        public void Initialize(IRestrictor restrictor)
        {
            _restrictor = restrictor;
        }

        public void Move(Vector2 direction, float deltaTime)
        {
            var nextPosition = _moveComponent.CalculateNextPosition(direction, deltaTime);
            var restrictedPosition = _restrictor.Restrict(nextPosition);
            _moveComponent.MoveTo(restrictedPosition);
        }
    }
}
