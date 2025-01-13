using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public float Speed = 5.0f;

        public void MoveTo(Vector2 targetPosition)
        {
            _rigidbody2D.MovePosition(targetPosition);
        }

        public Vector2 Position => _rigidbody2D.position;

        public Vector2 CalculateNextPosition(Vector2 movementDirection)
        {
            return _rigidbody2D.position + Speed * Time.fixedDeltaTime * movementDirection;
        }

        public void MoveInDirection(DirectionData directionData)
        {
            _rigidbody2D.position = CalculateNextPosition(directionData.Direction);
        }

        public void MoveInDirectionToPoint(Vector2 target)
        {
            var direction = target - (Vector2)transform.position;
            var directionData = new DirectionData(direction);
            MoveInDirection(directionData);
        }
    }
}
