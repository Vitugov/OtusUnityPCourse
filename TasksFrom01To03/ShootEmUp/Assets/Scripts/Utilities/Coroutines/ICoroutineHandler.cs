using System;
using UnityEngine;

namespace ShootEmUp
{
    public interface ICoroutineHandler
    {
        event Action CoroutineFinished;
        public bool IsPaused { get; }
        void Start(GameObject target);
        void Pause();
        void Resume();
        void Stop();
    }
}