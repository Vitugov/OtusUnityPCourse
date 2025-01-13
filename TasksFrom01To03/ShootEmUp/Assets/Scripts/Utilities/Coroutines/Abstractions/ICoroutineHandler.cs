using System;

namespace ShootEmUp
{
    public interface ICoroutineHandler
    {
        event Action CoroutineFinished;
        public bool IsPaused { get; set; }
        void Start();
        void Stop();
    }
}