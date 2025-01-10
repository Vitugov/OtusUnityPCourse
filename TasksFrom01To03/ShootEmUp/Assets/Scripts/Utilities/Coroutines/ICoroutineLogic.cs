using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public interface ICoroutineLogic
    {
        void Initialize(ICoroutineHandler handler, GameObject target);
        IEnumerator Execute();
    }
}
