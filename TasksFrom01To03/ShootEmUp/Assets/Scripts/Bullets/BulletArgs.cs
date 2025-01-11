using UnityEngine;

namespace ShootEmUp
{
    public readonly struct BulletArgs
    {
        public readonly Vector2 Position;
        public readonly Vector2 Direction;

        public BulletArgs(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
