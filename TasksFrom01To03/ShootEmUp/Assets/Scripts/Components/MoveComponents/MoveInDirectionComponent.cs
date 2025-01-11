using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveInDirectionComponent : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        
        private Vector2 _direction;

        public void Initialize(Vector2 direction)
        {
            _direction = direction;
        }

        public void Tick()
        {
            _moveComponent.MoveInDirection(_direction);
        }
    }
}
