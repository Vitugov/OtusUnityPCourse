using System;
using UnityEngine;


namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour, IHitPoints
    {
        public event Action<GameObject> HpEmpty;

        [SerializeField] private int _hitPoints;

        public int HitPoints
        {
            get => _hitPoints;
            set => _hitPoints = value;
        }

        public bool IsHitPointsExists()
        {
            return _hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;
            if (_hitPoints <= 0)
            {
                HpEmpty?.Invoke(gameObject);
            }
        }
    }
}