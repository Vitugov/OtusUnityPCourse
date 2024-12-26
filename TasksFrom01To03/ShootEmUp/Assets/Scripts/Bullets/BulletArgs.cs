using UnityEngine;


namespace ShootEmUp
{
    public readonly struct BulletArgs
    {
        public readonly BulletConfig Config;
        public readonly Vector2 Position;
        public readonly Vector2 Direction;
        public readonly Vector2 Velocity => Config.Speed * Direction.normalized;

        public BulletArgs(BulletConfig config, Vector2 position, Vector2 direction)
        {
            Config = config;
            Position = position;
            Direction = direction;
        }
    }
}
