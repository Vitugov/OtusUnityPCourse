using UnityEngine;


namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _speed = 5.0f;

        public void MoveTo(Vector2 targetPosition)
        {
            _rigidbody2D.MovePosition(targetPosition);
        }

        public Vector2 CalculateNextPosition(Vector2 movementDirection, float deltaTime)
        {
            return _rigidbody2D.position + _speed * deltaTime * movementDirection;
        }

        public void MoveInDirection(Vector2 direction)
        {
            _rigidbody2D.velocity = _speed * direction.normalized;
        }

        public void MoveInDirectionToPoint(Vector2 target)
        {
            var direction = target - (Vector2)transform.position;
            MoveInDirection(direction);
        }
    }
}