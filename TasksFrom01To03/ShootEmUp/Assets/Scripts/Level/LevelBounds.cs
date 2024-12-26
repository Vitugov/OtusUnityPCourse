using UnityEngine;


namespace ShootEmUp
{
    public sealed class LevelBounds : MonoBehaviour, IRestrictor
    {
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _bottomBorder;
        [SerializeField] private Transform _topBorder;

        private Vector2 LeftBorder => _leftBorder.position;
        private Vector2 RightBorder => _rightBorder.position;
        private Vector2 BottomBorder => _bottomBorder.position;
        private Vector2 TopBorder => _topBorder.position;

        public bool InBounds(Vector3 position)
        {
            return position.x > LeftBorder.x && position.x < RightBorder.x &&
                   position.y > BottomBorder.y && position.y < TopBorder.y;
        }

        public Vector2 Restrict(Vector2 targetPosition)
        {
            float restrictedX = Mathf.Clamp(targetPosition.x,
                                            LeftBorder.x,
                                            RightBorder.x);
            float restrictedY = Mathf.Clamp(targetPosition.y,
                                            BottomBorder.y,
                                            TopBorder.y);

            return new Vector2(restrictedX, restrictedY);
        }
    }
}