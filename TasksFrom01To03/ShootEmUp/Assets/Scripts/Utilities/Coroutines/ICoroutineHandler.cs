using System;
using UnityEngine;

namespace ShootEmUp
{
    public interface ICoroutineHandler
    {
        event Action CoroutineFinished;
        public bool IsPaused { get; set; }
        void Start(GameObject target);
        void Stop();
    }
}