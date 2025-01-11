using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class OutOfBoundsNotifier : MonoBehaviour
    {
        public event Action OutOfBounds;

        private LevelBounds _levelBounds;

        public void Initialize(LevelBounds levelBounds)
        {
            _levelBounds = levelBounds;
        }

        public void Tick()
        {
            if (!_levelBounds.InBounds(transform.position))
            {
                OutOfBounds?.Invoke();
            }
        }
    }
}
