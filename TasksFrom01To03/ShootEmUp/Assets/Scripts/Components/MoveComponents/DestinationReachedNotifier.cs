using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class DestinationReachedNotifier : MonoBehaviour
    {
        public event Action DestinationReached;

        private const double TRESHHOLD = 0.25;

        private Vector2 _destination;
        public bool IsDestinationReached { get; private set; }

        public void Initialize(Vector2 destination)
        {
            _destination = destination;
            IsDestinationReached = false;
        }

        public void Tick()
        {
            if (IsDestinationReached) { return; }

            var direction = (Vector2)transform.position - _destination;
            if (direction.magnitude < TRESHHOLD)
            {
                IsDestinationReached = true;
                DestinationReached?.Invoke();
            }
        }
    }
}
