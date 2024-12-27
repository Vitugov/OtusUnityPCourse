using UnityEngine;

namespace ShootEmUp
{
    public struct CharacterData
    {
        public int HitPoints;
        public Vector2 Position;

        public CharacterData(int healthPoints, Vector2 position)
        {
            HitPoints = healthPoints;
            Position = position;
        }
    }
}
