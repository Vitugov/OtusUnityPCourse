using UnityEngine;


namespace ShootEmUp
{
    public interface IRestrictor
    {
        Vector2 Restrict(Vector2 targetPosition);
    }
}