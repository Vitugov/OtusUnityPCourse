using System;
using UnityEngine;


namespace ShootEmUp
{
    public interface IHitPoints
    {
        event Action<GameObject> HpEmpty;

        bool IsHitPointsExists();
        void TakeDamage(int damage);
    }
}